namespace porTIEVserver.Domain.Abstractions
{
    public abstract class Entity
    {
        public int          Ref             { get; set; } = 0;
        public bool         Active          { get; set; } = true;
        public int          CreatedUser     { get; set; } = -1;
        public DateTime     CreatedDate     { get; set; } = DateTime.UtcNow;
        public int          LastUpdatedUser { get; set; } = -1;
        public DateTime?    LastUpdatedDate { get; set; }
        public bool         IsDeleted       { get; set; } = false;
        protected Entity()
        {
            Ref = 0;
        }
    }
}
