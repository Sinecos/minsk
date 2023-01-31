﻿using System;

namespace mc
{
    //https://youtu.be/wgHIkdUQbp0?list=PLRAdsfhKI4OWNOSfS7EUu5GRAVmze1t2y&t=1350
    class Program{
        static void Main(string[] args){
            while (true){

                Console.Write("> ");

                var line = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(line))
                    return;

                if(line == "1 + 2 * 3")
                    Console.WriteLine("7");
                else
                    Console.WriteLine("ERROR: Invalid expression!");
            }
        }
    }

    enum SyntaxKind
    {
        NumberToken
    }

    class SyntaxToken
    {
       public SyntaxToken(SyntaxKind kind, int position, string text, object value)
       {
            Kind = kind;
            Position = position;
            Text = text;
       }  

       public SyntaxKind Kind {get; }
       public int Position {get; }
       public string Text {get; }
       public object Value {get; }
       
    }

    class Lexer
    {
        private readonly string _text;
        private int _position;
        public Lexer(string text){
            _text = text;
        }

        private char Current
        {
            get
            {
                if(_position >= _text.Length)
                    return '\0';

                return _text[_position];
            }
        }

        private void Next(){
            _position++;
        }

        public SyntaxToken NextToken()
        {
            // <numbers>
            // + - *
            // <whitespace>

            if(char.IsDigit(Current))
            {
                var start = _position;

                while(char.IsDigit(Current))
                    Next();

                var lenght = _position - start;
                var text = _text.Substring(start, lenght);
                int.TryParse(text, out var value);
                return new SyntaxToken(SyntaxKind.NumberToken, start, text, value);
            }
        }

        if(char.Is)
    }
}