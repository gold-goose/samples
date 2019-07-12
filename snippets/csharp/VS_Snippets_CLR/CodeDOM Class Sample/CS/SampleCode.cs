﻿//<Snippet99>
//--------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//--------------------------------------------------------------------------

namespace CodeDOMSample
{
    using System;
    
    
    public sealed class CodeDOMCreatedClass
    {
        
        // The width of the object.
        private double widthValue;
        
        // The height of the object.
        private double heightValue;
        
        public CodeDOMCreatedClass(double width, double height)
        {
            this.widthValue = width;
            this.heightValue = height;
        }
        
        // The Width property for the object.
        public double Width
        {
            get
            {
                return this.widthValue;
            }
        }
        
        // The Height property for the object.
        public double Height
        {
            get
            {
                return this.heightValue;
            }
        }
        
        // The Area property for the object.
        public double Area
        {
            get
            {
                return (this.widthValue * this.heightValue);
            }
        }
        
        public override string ToString()
        {
            return string.Format(
                "The object:\r\n width = {0},\r\n height = {1},\r\n area = {2}", 
                this.Width, this.Height, this.Area);
        }
        
        public static void Main()
        {
            CodeDOMCreatedClass testClass = new CodeDOMCreatedClass(5.3, 6.9);
            System.Console.WriteLine(testClass.ToString());
        }
    }
}
//</Snippet99>