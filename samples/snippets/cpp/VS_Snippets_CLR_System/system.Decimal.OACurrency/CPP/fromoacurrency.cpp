
//<Snippet2>
// Example of the Decimal::FromOACurrency method. 
using namespace System;
#define dataFmt "{0,21}{1,25}"

// Display the Decimal::FromOACurrency parameter and Decimal result.
void ShowDecimalFromOACurrency( __int64 Argument )
{
   Decimal decCurrency = Decimal::FromOACurrency( Argument );
   Console::WriteLine( dataFmt, Argument, decCurrency );
}

int main()
{
   Console::WriteLine( "This example of the "
   "Decimal::FromOACurrency( ) method generates \nthe "
   "following output. It displays the OLE Automation "
   "Currency \nvalue as an __int64 and the result as a "
   "Decimal.\n" );
   Console::WriteLine( dataFmt, "OA Currency", "Decimal Value" );
   Console::WriteLine( dataFmt, "-----------", "-------------" );
   
   // Convert OLE Automation Currency values to Decimal objects.
   ShowDecimalFromOACurrency( 0L );
   ShowDecimalFromOACurrency( 1L );
   ShowDecimalFromOACurrency( 100000L );
   ShowDecimalFromOACurrency( 100000000000L );
   ShowDecimalFromOACurrency( 1000000000000000000L );
   ShowDecimalFromOACurrency( 1000000000000000001L );
   ShowDecimalFromOACurrency( Int64::MaxValue );
   ShowDecimalFromOACurrency( Int64::MinValue );
   ShowDecimalFromOACurrency( 123456789L );
   ShowDecimalFromOACurrency( 1234567890000L );
   ShowDecimalFromOACurrency( 1234567890987654321 );
   ShowDecimalFromOACurrency( 4294967295L );
}

/*
This example of the Decimal::FromOACurrency( ) method generates
the following output. It displays the OLE Automation Currency
value as an __int64 and the result as a Decimal.

          OA Currency            Decimal Value
          -----------            -------------
                    0                        0
                    1                   0.0001
               100000                       10
         100000000000                 10000000
  1000000000000000000          100000000000000
  1000000000000000001     100000000000000.0001
  9223372036854775807     922337203685477.5807
 -9223372036854775808    -922337203685477.5808
            123456789               12345.6789
        1234567890000                123456789
  1234567890987654321     123456789098765.4321
           4294967295              429496.7295
*/
//</Snippet2>
