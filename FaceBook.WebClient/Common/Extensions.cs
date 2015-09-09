namespace FaceBook.WebClient.Common
{
    using System.Linq;
    using System.Web.UI;

    public static class Extensions
    {
        public static Control NextControl(this Control control)
        {
            ControlCollection siblings = control.Parent.Controls;
            for (int i = siblings.IndexOf(control) + 1; i < siblings.Count; i++)
            {
                if (siblings[i].GetType() != typeof(LiteralControl) && siblings[i].GetType().BaseType != typeof(LiteralControl))
                {
                    return siblings[i];
                }
            }
            return null;
        }
    }
}