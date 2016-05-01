﻿namespace tomenglertde.ResXManager.View.Visuals
{
    using System;
    using System.Windows;

    using TomsToolbox.Core;
    using TomsToolbox.Desktop;

    /// <summary>
    /// Input box shows a prompt to enter a string.
    /// </summary>
    public partial class InputBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputBox"/> class.
        /// </summary>
        public InputBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A callback to validate the input text.
        /// </summary>
        public event EventHandler<TextEventArgs> TextChanged;

        /// <summary>
        /// Gets or sets the prompt to be displayed.
        /// </summary>
        public string Prompt
        {
            get { return (string)GetValue(PromptProperty); }
            set { SetValue(PromptProperty, value); }
        }
        /// <summary>
        /// Identifies the Prompt dependency property
        /// </summary>
        public static readonly DependencyProperty PromptProperty =
            DependencyProperty.Register("Prompt", typeof(string), typeof(InputBox));

        /// <summary>
        /// Gets or sets the text that the user has entered.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        /// <summary>
        /// Identifies the Text dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(InputBox), new FrameworkPropertyMetadata(null, (sender, e) => ((InputBox)sender).Text_Changed((string)e.NewValue)));

        private void Text_Changed(string newValue)
        {
            var eventHandler = TextChanged;

            if (eventHandler != null)
            {
                eventHandler(this, new TextEventArgs(newValue ?? string.Empty));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the text is valid input.
        /// </summary>
        public bool IsInputValid
        {
            get { return this.GetValue<bool>(IsInputValidProperty); }
            set { SetValue(IsInputValidProperty, value); }
        }
        /// <summary>
        /// Identifies the IsInputValid dependency property
        /// </summary>
        public static readonly DependencyProperty IsInputValidProperty =
            DependencyProperty.Register("IsInputValid", typeof(bool), typeof(InputBox));


        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        } 
    }
}
