﻿using System;
namespace firstApiTask.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Employee>? Employees { get; set; }
    }
}

