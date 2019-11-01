namespace lab_49_MVC_Core_Todo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            ToDoItems = new HashSet<ToDoItem>();
        }

        public int UserID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        public DateTime LastLoggedIn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
