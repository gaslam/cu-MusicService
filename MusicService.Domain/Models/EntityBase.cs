using System;

namespace MusicService.Domain.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        private DateTime? created;
        public DateTime? Created
        {
            get
            {
                return created ?? DateTime.Now;
            }

            set
            {
                if (value != null)
                    created = value;
                else created = DateTime.Now;
            }
        }
    }
}
