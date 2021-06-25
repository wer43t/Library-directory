﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Core
{
    public abstract class CatalogObject
    {
        string Name { get; set; }
        string Creator { get; set; }

        public CatalogObject(string Name, string Creator)
        {
            this.Name = Name;
            this.Creator = Creator;
        }
    }
    [Serializable]
    public class Book : CatalogObject
    {
        string authors;
        string illustrator;
        string publishingYear;

        public Book(string Name, string Creator, string authors, string illustrator, string publishingYear) : base (Name, Creator)
        {
            this.authors = authors;
            this.illustrator = illustrator;
            this.publishingYear = publishingYear;
        }
    }
    [Serializable]
    public class Puzzle : CatalogObject
    {
        string amountElements;

        public Puzzle(string Name, string Creator, string amountElements) : base(Name, Creator)
        {
            this.amountElements = amountElements;
        }
    }
    [Serializable]
    public class TableGame : CatalogObject
    {
        string description;
        string playerNumbers;

        public TableGame(string Name, string Creator, string description, string playerNumbers) : base(Name, Creator)
        {
            this.description = description;
            this.playerNumbers = playerNumbers;
        }
    }
}
