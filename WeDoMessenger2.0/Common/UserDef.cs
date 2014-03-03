using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Common {

    public class ListBoxItem : System.Object {
        public virtual string Text { get; set; }
        public virtual object Tag { get; set; }
        public virtual string Name { get; set; }
        public virtual object Object { get; set; }
        /// <summary>
        /// Class Constructor
        /// </summary>
        public ListBoxItem() {
            this.Text = string.Empty;
            this.Tag = null;
            this.Name = string.Empty;
            this.Object = null;
        }

        /// <summary>
        /// Overloaded Class Constructor
        /// </summary>
        /// <param name="Text">Object Text</param>
        /// <param name="Name">Object Name</param>
        /// <param name="Tag">Object Tag</param>
        /// <param name="Object">Object</param>
        public ListBoxItem(string Text, string Name, object Tag) {
            this.Text = Text;
            this.Tag = Tag;
            this.Name = Name;
            this.Object = Tag;
        }

        /// <summary>
        /// Overloaded Class Constructor
        /// </summary>
        /// <param name="Object">Object</param>
        public ListBoxItem(MemberObj userObj) {
            this.Text = string.Format("{0}({1})", userObj.Name, userObj.Id);
            this.Name = userObj.Id;
            this.Tag = userObj;
            this.Object = userObj;
        }

        /// <summary>
        /// Overridden ToString() Method
        /// </summary>
        /// <returns>Object Text</returns>
        public override string ToString() {
            return this.Text;
        }
    }
}
