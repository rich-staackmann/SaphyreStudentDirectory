namespace SaphyreStudentDirectory.Domain.Models
{
    /*
     This class serves as the basis for all entity objects in the domain.
     It provides basic implementation for equality operations. An entity is only equal if
     its Id is equal. Similar classes could be built for a Value object with with logic to verify
     all properties on two value objects are the same.
     */
    public abstract class Entity
    {
        int _Id;
        public virtual int ID
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;
            else
            {
                Entity item = (Entity)obj;
                return item.ID == this.ID;
            }
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null));
            else
                return left.Equals(right);
        }
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
