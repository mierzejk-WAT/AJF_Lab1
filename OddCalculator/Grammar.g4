grammar Grammar;

fragment SINGLE_SPACE   : '\u0020'; // ' '
fragment TABULATION     : '\u0009'; // '\t'
fragment LINE_FEED      : '\u000A'; // '\n'
fragment CARRAIGE_RETURN: '\u000D'; // '\r'

WhiteSpace    : ( SINGLE_SPACE | TABULATION )+ -> skip;
NewLine       : ( CARRAIGE_RETURN | LINE_FEED )+ -> skip;

Add           : '+';
Subtract      : '-';
Multiply      : '*';
Divide        : '/';
Colon         : ':' -> type(Divide);
Pow           : '^';
MultiMultiply : '**';
Modulo        : '%';
Ceiling       : ['];
Floor         : '_';
LB            : '(';
RB            : ')';
SQRT          : 'sqrt';
Round		  : 'round';
Min           : 'min';
Max           : 'max';
Comma         : ',';
Factorial     : '!';
Log           : 'log';
Logn          : 'logn';
Exp           : 'exp';
Abs           : 'abs';
Help		  : 'help';

OctNumber: [0][0-7]*[1357];

DecNumber: [1-9]*[0-9]*[13579];

HexNumber: [0][x][0-9A-F]*[13579BDF];

number: OctNumber | DecNumber | HexNumber;

operation:    op = Help
			| op = LB operation op = RB
			| op = Subtract operation
            | operation op = Pow operation 
			| op = SQRT operation 
			| operation op = MultiMultiply
            | operation op = ( Multiply | Divide | Modulo ) operation
            | operation op = ( Add | Subtract ) operation
            | operation op = ( Floor | Ceiling | Round )
			| op = Exp operation
			| op = Abs operation
			| op = Logn operation
			| op = Log number LB operation RB
			| op = ( Min | Max ) LB operation Comma operation RB
			| operation op = Factorial
            | number;