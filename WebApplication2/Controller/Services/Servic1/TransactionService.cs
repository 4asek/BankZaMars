using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controller.Services.Contracts;
using WebApplication2.Controllers.Services.Contraxts;
using WebApplication2.Data;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controller.Services.Servic1
{

        public class TransactionService : ITransactionServices
        {
            private readonly DataContext _context;

            public TransactionService(DataContext context)
            {
                _context = context;
            }
            async Task<Transactions> ITransactionServices.AddTransactions(TransactionRequesModel transaction)
            {
                if (transaction == null)
                {
                    throw new ArgumentNullException(nameof(transaction));
                }
                var res = MapRequestToCard(transaction);

                _context.Transactions.AddAsync(res);
                await _context.SaveChangesAsync();

                return res;
            }

            async Task<Guid> ITransactionServices.DeleteTransactions(Guid id)
            {
                var transactions = await _context.Transactions.FindAsync(id);
                if (transactions == null)
                {
                    return Guid.Empty;
                }

                transactions.CardID = Guid.Empty;

                _context.Transactions.Remove(transactions);
                await _context.SaveChangesAsync();

                return id;
            }

            async Task<ActionResult<List<Transactions>>> ITransactionServices.GetAllTransaction()
            {
                var transactions = await _context.Transactions.ToListAsync();

                return transactions;
            }

            async Task<TransactionRequesModel> ITransactionServices.GetTransaction(Guid id)
            {
                var transaction = await _context.Transactions.FindAsync(id);

                if (transaction == null)
                {
                    return null;
                }
                var res = MapRequestToDB(transaction);

                return res;
            }

            async Task<Guid> ITransactionServices.UpdateTransactions(Guid id, TransactionRequesModel requestModel)
            {
                var transactions = await _context.Transactions.FindAsync(id);
                if (transactions == null)
                {
                    return Guid.Empty;
                }
                transactions = MapRequestToSet(transactions, requestModel);
                _context.Transactions.Update(transactions);
                await _context.SaveChangesAsync();

                return id;
            }

            private Transactions MapRequestToCard(TransactionRequesModel requestModel)
            {
                var transaction = new Transactions();
                transaction.Id = Guid.NewGuid();

                transaction.TransactionDate = requestModel.TransactionDate;
                transaction.Suma = requestModel.Suma;
                transaction.readiness = requestModel.readiness;
                transaction.CardID = requestModel.CardID;
  
                return transaction;
            }

            private TransactionRequesModel MapRequestToDB(Transactions transactions)
            {
                var requestModel = new TransactionRequesModel();
                requestModel.TransactionDate = transactions.TransactionDate;
                requestModel.Suma = transactions.Suma;
                requestModel.readiness = transactions.readiness;
                return requestModel;
            }

            private Transactions MapRequestToSet(Transactions res, TransactionRequesModel transaction)
            {
                res.TransactionDate = transaction.TransactionDate;
                res.Suma = transaction.Suma;
                res.readiness = transaction.readiness;

                return res;
            }
        }
    }
