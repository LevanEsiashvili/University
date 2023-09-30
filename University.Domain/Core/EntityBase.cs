namespace University.Domain.Core
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public EntityBase() 
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            IsDeleted = false;
        }

        public EntityBase(Guid id)
        {
            Id = id;
            CreatedDate = DateTime.Now;
        }

        public void Delete()
        {
            if (IsDeleted)
            {
                throw new Exception("ობიექტი უკვე წაშლილია");
            }
            IsDeleted = true;
        }
    }
}
