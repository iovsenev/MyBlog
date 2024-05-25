using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Domain.Entities
{
    public class AppUser
    {
        private AppUser(
            Guid id, 
            string userName, 
            string passwordHash, 
            string email, 
            string? phone, 
            string firstName, 
            string lastName,
            string? secondName, 
            DateTime birthDate,
            DateTime registrationDate,
            Guid roleId, 
            Role role)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;
            BirthDate = birthDate;
            RegistrationDate = registrationDate;
            RoleId = roleId;
            Role = role;
            Articles = new();
            Comments = new();
        }

        public Guid Id { get;private set; }
        [Required]
        public string UserName { get;private set; }
        [Required]
        public string PasswordHash { get;private set; }
        [Required, EmailAddress]
        public string Email { get;private set; }
        public string? Phone { get;private set; }

        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public string? SecondName { get;private set; }
        public DateTime BirthDate { get;private set; }
        public DateTime RegistrationDate { get;private set; }

        public Guid RoleId { get;private set; }
        [ForeignKey(nameof(RoleId))]
        public Role Role { get;private set; }

        public List<Article> Articles { get;private set; }
        public List<Comment> Comments { get;private set; }
    }
}
