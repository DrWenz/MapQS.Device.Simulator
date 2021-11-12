using System;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Data;

namespace MapQS.Device.Simulator
{
    public class ClassSetters : AvaloniaList<ClassSetter>
    {
    }

    public class ClassSetter : AvaloniaObject
    {
        public static readonly DirectProperty<ClassSetter, string> NameProperty
            = AvaloniaProperty.RegisterDirect<ClassSetter, string>(nameof(Name), s => s.Name, (s, v) => s.Name = v,
                defaultBindingMode: BindingMode.OneWay);

        public static readonly StyledProperty<bool> TriggerProperty
            = AvaloniaProperty.Register<ClassSetter, bool>(nameof(Trigger));

        public static readonly StyledProperty<Control> AssociatedObjectProperty
            = AvaloniaProperty.Register<ClassSetter, Control>(nameof(AssociatedObject));

        public static readonly AttachedProperty<ClassSetters> ClassesProperty
            = AvaloniaProperty.RegisterAttached<ClassSetter, Control, ClassSetters>("Classes", new ClassSetters(),
                true);

        private string name;
        private bool trigger;

        static ClassSetter()
        {
        }

        public string Name
        {
            get => name;
            set => SetAndRaise(NameProperty, ref name, value);
        }

        public bool Trigger
        {
            get => GetValue(TriggerProperty);
            set => SetAndRaise(TriggerProperty, ref trigger, value);
        }

        public Control AssociatedObject
        {
            get => GetValue(AssociatedObjectProperty);
            set => SetValue(AssociatedObjectProperty, value);
        }
        
        public static ClassSetters GetClasses(AvaloniaObject obj)
        {
            return obj.GetValue(ClassesProperty);
        }

        public static void SetClasses(AvaloniaObject obj, ClassSetters classes)
        {
            obj.SetValue(ClassesProperty, classes);
        }
        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            base.OnPropertyChanged(change);
            if (AssociatedObject != null)
            {
                AssociatedObject.Classes.Set(Name, Trigger);
            }
        }
    }
}