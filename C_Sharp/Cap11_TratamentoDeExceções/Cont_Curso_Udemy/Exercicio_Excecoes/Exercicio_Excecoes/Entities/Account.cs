﻿using System.Globalization;
using Exercicio_Excecoes.Entities.Exceptions;

namespace Exercicio_Excecoes.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new DomainException("Not enough balance.");
            }
            else if (amount > WithdrawLimit)
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine("New balance: " + Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
        }

        public override string ToString()
        {
            return $"{Number}, {Holder}, {Balance}, {WithdrawLimit}";
        }
    }
}
