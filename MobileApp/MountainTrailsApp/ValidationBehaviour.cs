using Microsoft.Maui.Controls;

namespace MountainTrailsApp
{
    public class ValidationBehaviour : Behavior<Editor>
    {
        protected override void OnAttachedTo(Editor editor)
        {
            editor.TextChanged += OnEditorTextChanged;
            base.OnAttachedTo(editor);
        }

        protected override void OnDetachingFrom(Editor editor)
        {
            editor.TextChanged -= OnEditorTextChanged;
            base.OnDetachingFrom(editor);
        }

        void OnEditorTextChanged(object sender, TextChangedEventArgs args)
        {
            ((Editor)sender).BackgroundColor =
                string.IsNullOrEmpty(args.NewTextValue)
                ? Color.FromRgba("#AA4A44")   // roșu dacă e gol
                : Color.FromRgba("#FFFFFF");  // alb dacă e ok
        }
    }
}
