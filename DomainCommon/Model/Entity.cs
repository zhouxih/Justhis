
namespace DomainCommon.Model
{
    /// <summary>
    /// 实体抽象基类
    /// </summary>
    public abstract class Entity:IEntity
    {
        public Guid Id { get ; protected set; } = Guid.NewGuid();

        #region 重写Equals 、GetHashCode、ToString

        public override bool Equals(object obj)
        {
            var compareEntity = obj as Entity;
            if(ReferenceEquals(compareEntity,null)) return false;
            if(ReferenceEquals(compareEntity,this)) return true;
            return this.Id.Equals(compareEntity.Id);
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode() * 907 + this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"[Name:{this.GetType().Name},Id:{this.Id.ToString()}]";
        }




        #endregion

        #region 重写比较符

        /// <summary>
        /// 重写方法 实体比较 ==
        /// </summary>
        /// <param name="a">领域实体a</param>
        /// <param name="b">领域实体b</param>
        /// <returns></returns>
        public static bool operator == (Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        /// <summary>
        /// 重写方法 实体比较 !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator != (Entity a, Entity b)
        {
            return !(a == b);
        }

        #endregion

    }
}
