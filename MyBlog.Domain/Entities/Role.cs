﻿namespace MyBlog.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IReadOnlyList<AppUser> Users { get; set; }
    }
}