﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace diskusiPR.Models;

public partial class Jawaban
{
    public int IdJawaban { get; set; }

    public int Author { get; set; }

    public string Jawaban1 { get; set; }

    public virtual User AuthorNavigation { get; set; }

    public virtual ICollection<SoalJawaban> SoalJawabans { get; set; } = new List<SoalJawaban>();
}