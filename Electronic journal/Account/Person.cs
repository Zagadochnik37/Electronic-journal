﻿using System;
using System.IO;

namespace Electronic_journal
{
    public abstract class Person : Account
    {
        [Editor("Имя"), StringParams(AllowEmpty = false)]
        public string FirstName { get; set; }
        [Editor("Фамилия"), StringParams(AllowEmpty = false)]
        public string LastName { get; set; }
        [Editor("Отчество"), StringParams(AllowEmpty = false)]
        public string Patronymic { get; set; }
        [Editor("Дата рождения"), DateTimeParams(OnlyDate = true)]
        public DateTime Birthday { get; set; }
        public Person(string login, string password, AccountType type, string firstName, string lastName, string patronymic, DateTime birthday) : base(login, password, type)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Birthday = birthday;
        }
        public Person(string login, string password, AccountType type, BinaryReader reader) : base(login, password, type)
        {
            FirstName = reader.ReadString();
            LastName = reader.ReadString();
            Patronymic = reader.ReadString();
            Birthday = reader.ReadDateTime();
        }
        public Person(AccountType type, BinaryReader reader) : base(reader, type)
        {
            FirstName = reader.ReadString();
            LastName = reader.ReadString();
            Patronymic = reader.ReadString();
            Birthday = reader.ReadDateTime();
        }

        public override void Export(BinaryWriter writer)
        {
            base.Export(writer);
            writer.Write(FirstName);
            writer.Write(LastName);
            writer.Write(Patronymic);
            writer.Write(Birthday);
        }
    }
}
