﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Todo
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool MarkedDone { get; set; }
        
    }
}