using Flunt.Notifications;
using System;


namespace School.Domain.Shared
{
    public abstract class Entity:Notifiable
    {
        public Entity()
        {
            ID = Guid.NewGuid();
         
        }

        public Guid ID { get; private set; }
      

        public virtual void Validate()
        {
            
        }
    }
}
