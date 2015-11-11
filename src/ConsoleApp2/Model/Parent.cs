namespace ConsoleApp2.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// A parent entity containing a <see cref="ChildA"/> entity and a <see cref="List{T}"/> of <see cref="ChildBs "/> entities. 
    /// </summary>
    public class Parent
    {
        /// <summary>
        /// Gets or sets the uniquely define <see cref="Parent"/> Id.
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets some dummy data in this entity.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="ChildA"/> entity.
        /// </summary>
        public ChildA ChildA { get; set; }
    }
}