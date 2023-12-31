﻿using KaniniTourism.Models;
using Microsoft.AspNetCore.Mvc;

namespace KaniniTourism.Repository.TransactionServices
{
    public interface ITransactionRepo
    {
        Task<ActionResult<List<Transaction>>> GetAllTransaction();
        Task<ActionResult<List<Transaction>>> PostTransaction(Transaction transaction);
    }
}
