using System;
using System.Collections.Generic;

public class FinanceApp
{
    private List<Transaction> _transactions = new List<Transaction>();

    public void Run()
    {
        SavingsAccount myAccount = new SavingsAccount("ACC12345", 1000m);

        Transaction t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
        Transaction t2 = new Transaction(2, DateTime.Now, 200m, "Utilities");
        Transaction t3 = new Transaction(3, DateTime.Now, 500m, "Entertainment");

        ITransactionProcessor mobileProcessor = new MobileMoneyProcessor();
        ITransactionProcessor bankProcessor = new BankTransferProcessor();
        ITransactionProcessor cryptoProcessor = new CryptoWalletProcessor();

        mobileProcessor.Process(t1);
        bankProcessor.Process(t2);
        cryptoProcessor.Process(t3);

        myAccount.ApplyTransaction(t1);
        myAccount.ApplyTransaction(t2);
        myAccount.ApplyTransaction(t3);

        _transactions.Add(t1);
        _transactions.Add(t2);
        _transactions.Add(t3);
    }
}
