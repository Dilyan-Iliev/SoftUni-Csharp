﻿namespace Contacts.Core.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUserContact
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Contact))]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
