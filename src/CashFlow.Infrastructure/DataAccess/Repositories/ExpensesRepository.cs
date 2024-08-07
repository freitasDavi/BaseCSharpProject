﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesReadOnlyRepository, IExpensesWriteOnlyRepository, IExpensesUpdateOnlyRepository
    {
        private readonly CashFlowDbContext _dbContext;
        public ExpensesRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Expense expense)
        {
            await _dbContext.Expenses.AddAsync(expense);
        }

        public async Task Delete(long id)
        {
            var result = await _dbContext.Expenses.FirstAsync(e => e.Id == id);

            _dbContext.Expenses.Remove(result);
        }

        public async Task<List<Expense>> GetAll(User u)
        {
            return await _dbContext.Expenses.AsNoTracking().Where(e => e.UserId == u.Id).ToListAsync();
        }

        async Task<Expense?> IExpensesReadOnlyRepository.GetById(User user, long id)
        {
            return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(x => 
                x.Id == id &&
                x.UserId == user.Id
            );
        }

        async Task<Expense?> IExpensesUpdateOnlyRepository.GetById(User user, long id)
        {
            return await _dbContext.Expenses.FirstOrDefaultAsync(x => 
                x.Id == id &&
                x.UserId == user.Id
            );
        }

        public void Update(Expense expense)
        {
            _dbContext.Expenses.Update(expense);
        }

        public async Task<List<Expense>> FilterByMonth(User user, DateOnly date)
        {
            var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

            var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);

            var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

            return await _dbContext
                            .Expenses
                            .AsNoTracking()
                            .Where(e => e.UserId == user.Id &&
                                e.Date >= startDate && e.Date <= endDate)
                            .OrderBy(e => e.Date)
                            .ThenBy(e => e.Title)
                            .ToListAsync();
        }

        public async Task<decimal> GetTotalExpenses(long userId)
        {
            return await _dbContext.Expenses.AsNoTracking().Where(e => e.UserId == userId).SumAsync(e => e.Amount);
        }
    }
}
