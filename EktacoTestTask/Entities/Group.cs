﻿using System.Collections.Generic;

namespace EktacoTestTask.Entities
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

    }
}