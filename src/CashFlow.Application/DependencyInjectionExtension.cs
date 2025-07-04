﻿using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Clientes;
using CashFlow.Application.UseCases.Expenses;
using CashFlow.Application.UseCases.Expenses.Delete;
using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Application.UseCases.Expenses.Reports.Excel;
using CashFlow.Application.UseCases.Expenses.Reports.Pdf;
using CashFlow.Application.UseCases.Expenses.Update;
using CashFlow.Application.UseCases.Incomes;
using CashFlow.Application.UseCases.Orcamentos;
using CashFlow.Application.UseCases.Orcamentos.Itens;
using CashFlow.Application.UseCases.Pecas;
using CashFlow.Application.UseCases.Produtos;
using CashFlow.Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
            services.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
            services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
            services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
            services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
            services.AddScoped<IGenerateExpensesreportExcelUseCase, GenerateExpensesreportExcelUseCase>();
            services.AddScoped<IGenerateExpensesPdfReportUseCase, GenerateExpensesPdfReportUseCase>();

            services.AddScoped<IIncomesService, IncomesService>();
            services.AddScoped<IExpensesService, ExpensesServices>();

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IPecasService, PecasService>();
            services.AddScoped<IOrcamentoService, OrcamentoService>();
            services.AddScoped<IItensOrcamentoService, ItensOrcamentoService>();
            services.AddScoped<IClientesService, ClientesService>();
            services.AddScoped<IProdutosService, ProdutosService>();
        }
    }
}
