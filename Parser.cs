
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF            =  0, // (EOF)
        SYMBOL_ERROR          =  1, // (Error)
        SYMBOL_WHITESPACE     =  2, // Whitespace
        SYMBOL_MINUS          =  3, // '-'
        SYMBOL_MINUSMINUS     =  4, // '--'
        SYMBOL_EXCLAMEQ       =  5, // '!='
        SYMBOL_PERCENT        =  6, // '%'
        SYMBOL_LPAREN         =  7, // '('
        SYMBOL_RPAREN         =  8, // ')'
        SYMBOL_TIMES          =  9, // '*'
        SYMBOL_TIMESTIMES     = 10, // '**'
        SYMBOL_COMMA          = 11, // ','
        SYMBOL_DIV            = 12, // '/'
        SYMBOL_LBRACE         = 13, // '{'
        SYMBOL_RBRACE         = 14, // '}'
        SYMBOL_PLUS           = 15, // '+'
        SYMBOL_PLUSPLUS       = 16, // '++'
        SYMBOL_LT             = 17, // '< '
        SYMBOL_LTEQ           = 18, // '<='
        SYMBOL_EQ             = 19, // '='
        SYMBOL_EQEQ           = 20, // '=='
        SYMBOL_GT             = 21, // '>'
        SYMBOL_GTEQ           = 22, // '>='
        SYMBOL_CLASS          = 23, // Class
        SYMBOL_DIGT           = 24, // digt
        SYMBOL_DOUB           = 25, // doub
        SYMBOL_ELSE           = 26, // else
        SYMBOL_END            = 27, // End
        SYMBOL_FLOAUT         = 28, // floaut
        SYMBOL_FOR            = 29, // For
        SYMBOL_FUNC           = 30, // Func
        SYMBOL_IDENT          = 31, // Ident
        SYMBOL_IF             = 32, // If
        SYMBOL_IF_END         = 33, // 'If_end'
        SYMBOL_INTG           = 34, // intg
        SYMBOL_NEW            = 35, // New
        SYMBOL_RETURN         = 36, // Return
        SYMBOL_START          = 37, // Start
        SYMBOL_STRG           = 38, // strg
        SYMBOL_THEN           = 39, // then
        SYMBOL_VOID           = 40, // void
        SYMBOL_ARGUMENTS      = 41, // <arguments>
        SYMBOL_ASS_OP         = 42, // <ass_op>
        SYMBOL_CLASS_BODY     = 43, // <Class_Body>
        SYMBOL_CLASS_DECL     = 44, // <Class_Decl>
        SYMBOL_CLASS_ELEMENTS = 45, // <Class_elements>
        SYMBOL_CODING         = 46, // <Coding>
        SYMBOL_CONCEPT        = 47, // <concept>
        SYMBOL_COND           = 48, // <cond>
        SYMBOL_DIGT2          = 49, // <Digt>
        SYMBOL_DT             = 50, // <DT>
        SYMBOL_EXP            = 51, // <exp>
        SYMBOL_EXPO           = 52, // <expo>
        SYMBOL_FACT           = 53, // <fact>
        SYMBOL_FOR_STM        = 54, // <For_Stm>
        SYMBOL_ID             = 55, // <Id>
        SYMBOL_IF_STM         = 56, // <If_Stm>
        SYMBOL_METH_CALL      = 57, // <Meth_Call>
        SYMBOL_METH_DECLR     = 58, // <Meth_Declr>
        SYMBOL_OBJ_CREATION   = 59, // <obj_creation>
        SYMBOL_ONE_STP        = 60, // <one_stp>
        SYMBOL_OPR            = 61, // <opr>
        SYMBOL_PARMS          = 62, // <parms>
        SYMBOL_PRAM           = 63, // <pram>
        SYMBOL_PROGRAM        = 64, // <Program>
        SYMBOL_RET_STMT       = 65, // <Ret_Stmt>
        SYMBOL_RETURN_TYPE    = 66, // <return_type>
        SYMBOL_STMT           = 67, // <stmt>
        SYMBOL_STMTS          = 68, // <stmts>
        SYMBOL_TER            = 69, // <ter>
        SYMBOL_TYPE           = 70  // <type>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                           =  0, // <Program> ::= Start <Coding> End
        RULE_CODING                                      =  1, // <Coding> ::= <concept>
        RULE_CODING2                                     =  2, // <Coding> ::= <concept> <Coding>
        RULE_CONCEPT                                     =  3, // <concept> ::= <ass_op>
        RULE_CONCEPT2                                    =  4, // <concept> ::= <If_Stm>
        RULE_CONCEPT3                                    =  5, // <concept> ::= <For_Stm>
        RULE_CONCEPT4                                    =  6, // <concept> ::= <Meth_Declr>
        RULE_CONCEPT5                                    =  7, // <concept> ::= <Meth_Call>
        RULE_CONCEPT6                                    =  8, // <concept> ::= <Ret_Stmt>
        RULE_CONCEPT7                                    =  9, // <concept> ::= <Class_Decl>
        RULE_CONCEPT8                                    = 10, // <concept> ::= <obj_creation>
        RULE_ASS_OP_EQ                                   = 11, // <ass_op> ::= <Id> '=' <exp>
        RULE_ID_IDENT                                    = 12, // <Id> ::= Ident
        RULE_EXP_PLUS                                    = 13, // <exp> ::= <exp> '+' <ter>
        RULE_EXP_MINUS                                   = 14, // <exp> ::= <exp> '-' <ter>
        RULE_EXP                                         = 15, // <exp> ::= <ter>
        RULE_TER_TIMES                                   = 16, // <ter> ::= <ter> '*' <fact>
        RULE_TER_DIV                                     = 17, // <ter> ::= <ter> '/' <fact>
        RULE_TER_PERCENT                                 = 18, // <ter> ::= <ter> '%' <fact>
        RULE_TER                                         = 19, // <ter> ::= <fact>
        RULE_FACT_TIMESTIMES                             = 20, // <fact> ::= <fact> '**' <expo>
        RULE_FACT                                        = 21, // <fact> ::= <expo>
        RULE_EXPO_LPAREN_RPAREN                          = 22, // <expo> ::= '(' <exp> ')'
        RULE_EXPO                                        = 23, // <expo> ::= <Id>
        RULE_EXPO2                                       = 24, // <expo> ::= <Digt>
        RULE_DIGT_DIGT                                   = 25, // <Digt> ::= digt
        RULE_IF_STM_IF_LPAREN_RPAREN_THEN_IF_END         = 26, // <If_Stm> ::= If '(' <cond> ')' then <stmts> 'If_end'
        RULE_IF_STM_IF_LPAREN_RPAREN_THEN_IF_END_ELSE    = 27, // <If_Stm> ::= If '(' <cond> ')' then <stmts> 'If_end' else <stmts>
        RULE_COND                                        = 28, // <cond> ::= <exp> <opr> <exp>
        RULE_OPR_LT                                      = 29, // <opr> ::= '< '
        RULE_OPR_GT                                      = 30, // <opr> ::= '>'
        RULE_OPR_LTEQ                                    = 31, // <opr> ::= '<='
        RULE_OPR_GTEQ                                    = 32, // <opr> ::= '>='
        RULE_OPR_EQEQ                                    = 33, // <opr> ::= '=='
        RULE_OPR_EXCLAMEQ                                = 34, // <opr> ::= '!='
        RULE_STMTS                                       = 35, // <stmts> ::= <stmt>
        RULE_STMTS2                                      = 36, // <stmts> ::= <stmt> <stmts>
        RULE_STMT                                        = 37, // <stmt> ::= <ass_op>
        RULE_STMT2                                       = 38, // <stmt> ::= <For_Stm>
        RULE_STMT3                                       = 39, // <stmt> ::= <If_Stm>
        RULE_FOR_STM_FOR_LPAREN_RPAREN_LBRACE_RBRACE     = 40, // <For_Stm> ::= For '(' <DT> <ass_op> <cond> <one_stp> ')' '{' <stmts> '}'
        RULE_DT_INTG                                     = 41, // <DT> ::= intg
        RULE_DT_DOUB                                     = 42, // <DT> ::= doub
        RULE_DT_STRG                                     = 43, // <DT> ::= strg
        RULE_DT_FLOAUT                                   = 44, // <DT> ::= floaut
        RULE_ONE_STP_PLUSPLUS                            = 45, // <one_stp> ::= <Id> '++'
        RULE_ONE_STP_MINUSMINUS                          = 46, // <one_stp> ::= <Id> '--'
        RULE_ONE_STP_PLUSPLUS2                           = 47, // <one_stp> ::= '++' <Id>
        RULE_ONE_STP_MINUSMINUS2                         = 48, // <one_stp> ::= '--' <Id>
        RULE_ONE_STP                                     = 49, // <one_stp> ::= <ass_op>
        RULE_METH_DECLR_FUNC_LPAREN_RPAREN_LBRACE_RBRACE = 50, // <Meth_Declr> ::= Func <return_type> <Id> '(' <parms> ')' '{' <stmts> '}'
        RULE_RETURN_TYPE_VOID                            = 51, // <return_type> ::= void
        RULE_RETURN_TYPE                                 = 52, // <return_type> ::= <type>
        RULE_TYPE                                        = 53, // <type> ::= <DT>
        RULE_PARMS                                       = 54, // <parms> ::= <pram>
        RULE_PARMS_COMMA                                 = 55, // <parms> ::= <pram> ',' <parms>
        RULE_PRAM                                        = 56, // <pram> ::= <DT> <Id>
        RULE_METH_CALL_LPAREN_RPAREN                     = 57, // <Meth_Call> ::= <Id> '(' <arguments> ')'
        RULE_ARGUMENTS                                   = 58, // <arguments> ::= <exp>
        RULE_ARGUMENTS_COMMA                             = 59, // <arguments> ::= <exp> ',' <arguments>
        RULE_ARGUMENTS2                                  = 60, // <arguments> ::= 
        RULE_RET_STMT_RETURN                             = 61, // <Ret_Stmt> ::= Return <exp>
        RULE_RET_STMT_RETURN2                            = 62, // <Ret_Stmt> ::= Return
        RULE_CLASS_DECL_CLASS_LBRACE_RBRACE              = 63, // <Class_Decl> ::= Class <Id> '{' <Class_Body> '}'
        RULE_CLASS_BODY                                  = 64, // <Class_Body> ::= <Class_elements>
        RULE_CLASS_BODY2                                 = 65, // <Class_Body> ::= <Class_elements> <Class_Body>
        RULE_CLASS_ELEMENTS                              = 66, // <Class_elements> ::= <Meth_Declr>
        RULE_CLASS_ELEMENTS2                             = 67, // <Class_elements> ::= <ass_op>
        RULE_CLASS_ELEMENTS3                             = 68, // <Class_elements> ::= <If_Stm>
        RULE_CLASS_ELEMENTS4                             = 69, // <Class_elements> ::= <For_Stm>
        RULE_CLASS_ELEMENTS5                             = 70, // <Class_elements> ::= <Meth_Call>
        RULE_OBJ_CREATION_EQ_NEW_LPAREN_RPAREN           = 71  // <obj_creation> ::= <Id> <Id> '=' New <Id> '(' ')'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox listBox1;
         ListBox listBox2;
        public MyParser(string filename , ListBox listBox , ListBox listBox2)
        {
           

            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            listBox1 = listBox;
            this.listBox2 = listBox2;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);

            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'< '
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //Class
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGT :
                //digt
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUB :
                //doub
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAUT :
                //floaut
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //For
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC :
                //Func
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENT :
                //Ident
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //If
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_END :
                //'If_end'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTG :
                //intg
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEW :
                //New
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //Return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRG :
                //strg
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THEN :
                //then
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTS :
                //<arguments>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASS_OP :
                //<ass_op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS_BODY :
                //<Class_Body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS_DECL :
                //<Class_Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS_ELEMENTS :
                //<Class_elements>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CODING :
                //<Coding>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGT2 :
                //<Digt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DT :
                //<DT>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPO :
                //<expo>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACT :
                //<fact>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STM :
                //<For_Stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //<Id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STM :
                //<If_Stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METH_CALL :
                //<Meth_Call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METH_DECLR :
                //<Meth_Declr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OBJ_CREATION :
                //<obj_creation>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ONE_STP :
                //<one_stp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPR :
                //<opr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARMS :
                //<parms>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRAM :
                //<pram>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RET_STMT :
                //<Ret_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN_TYPE :
                //<return_type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT :
                //<stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMTS :
                //<stmts>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TER :
                //<ter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<type>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<Program> ::= Start <Coding> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODING :
                //<Coding> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODING2 :
                //<Coding> ::= <concept> <Coding>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <ass_op>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <If_Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <For_Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <Meth_Declr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <Meth_Call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT6 :
                //<concept> ::= <Ret_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT7 :
                //<concept> ::= <Class_Decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT8 :
                //<concept> ::= <obj_creation>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASS_OP_EQ :
                //<ass_op> ::= <Id> '=' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_IDENT :
                //<Id> ::= Ident
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_PLUS :
                //<exp> ::= <exp> '+' <ter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_MINUS :
                //<exp> ::= <exp> '-' <ter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <ter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TER_TIMES :
                //<ter> ::= <ter> '*' <fact>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TER_DIV :
                //<ter> ::= <ter> '/' <fact>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TER_PERCENT :
                //<ter> ::= <ter> '%' <fact>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TER :
                //<ter> ::= <fact>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACT_TIMESTIMES :
                //<fact> ::= <fact> '**' <expo>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACT :
                //<fact> ::= <expo>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPO_LPAREN_RPAREN :
                //<expo> ::= '(' <exp> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPO :
                //<expo> ::= <Id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPO2 :
                //<expo> ::= <Digt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGT_DIGT :
                //<Digt> ::= digt
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STM_IF_LPAREN_RPAREN_THEN_IF_END :
                //<If_Stm> ::= If '(' <cond> ')' then <stmts> 'If_end'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STM_IF_LPAREN_RPAREN_THEN_IF_END_ELSE :
                //<If_Stm> ::= If '(' <cond> ')' then <stmts> 'If_end' else <stmts>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <exp> <opr> <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPR_LT :
                //<opr> ::= '< '
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPR_GT :
                //<opr> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPR_LTEQ :
                //<opr> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPR_GTEQ :
                //<opr> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPR_EQEQ :
                //<opr> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPR_EXCLAMEQ :
                //<opr> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMTS :
                //<stmts> ::= <stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMTS2 :
                //<stmts> ::= <stmt> <stmts>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT :
                //<stmt> ::= <ass_op>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT2 :
                //<stmt> ::= <For_Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT3 :
                //<stmt> ::= <If_Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STM_FOR_LPAREN_RPAREN_LBRACE_RBRACE :
                //<For_Stm> ::= For '(' <DT> <ass_op> <cond> <one_stp> ')' '{' <stmts> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DT_INTG :
                //<DT> ::= intg
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DT_DOUB :
                //<DT> ::= doub
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DT_STRG :
                //<DT> ::= strg
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DT_FLOAUT :
                //<DT> ::= floaut
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ONE_STP_PLUSPLUS :
                //<one_stp> ::= <Id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ONE_STP_MINUSMINUS :
                //<one_stp> ::= <Id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ONE_STP_PLUSPLUS2 :
                //<one_stp> ::= '++' <Id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ONE_STP_MINUSMINUS2 :
                //<one_stp> ::= '--' <Id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ONE_STP :
                //<one_stp> ::= <ass_op>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METH_DECLR_FUNC_LPAREN_RPAREN_LBRACE_RBRACE :
                //<Meth_Declr> ::= Func <return_type> <Id> '(' <parms> ')' '{' <stmts> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_TYPE_VOID :
                //<return_type> ::= void
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_TYPE :
                //<return_type> ::= <type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE :
                //<type> ::= <DT>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARMS :
                //<parms> ::= <pram>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARMS_COMMA :
                //<parms> ::= <pram> ',' <parms>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRAM :
                //<pram> ::= <DT> <Id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METH_CALL_LPAREN_RPAREN :
                //<Meth_Call> ::= <Id> '(' <arguments> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS :
                //<arguments> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS_COMMA :
                //<arguments> ::= <exp> ',' <arguments>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS2 :
                //<arguments> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RET_STMT_RETURN :
                //<Ret_Stmt> ::= Return <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RET_STMT_RETURN2 :
                //<Ret_Stmt> ::= Return
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_DECL_CLASS_LBRACE_RBRACE :
                //<Class_Decl> ::= Class <Id> '{' <Class_Body> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_BODY :
                //<Class_Body> ::= <Class_elements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_BODY2 :
                //<Class_Body> ::= <Class_elements> <Class_Body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_ELEMENTS :
                //<Class_elements> ::= <Meth_Declr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_ELEMENTS2 :
                //<Class_elements> ::= <ass_op>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_ELEMENTS3 :
                //<Class_elements> ::= <If_Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_ELEMENTS4 :
                //<Class_elements> ::= <For_Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_ELEMENTS5 :
                //<Class_elements> ::= <Meth_Call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OBJ_CREATION_EQ_NEW_LPAREN_RPAREN :
                //<obj_creation> ::= <Id> <Id> '=' New <Id> '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+" in line :" + args.UnexpectedToken.Location.LineNr;
            listBox1.Items.Add(message);
            string message2 ="Expected token : "+ args.ExpectedTokens.ToString();
            listBox1.Items.Add(message2);
        }

        private void TokenReadEvent(LALRParser parser , TokenReadEventArgs args )
        {
            string message = "Token read: '"+args.Token.Text+"  \t\t"+ (SymbolConstants)args.Token.Symbol.Id ;
            listBox2.Items.Add(message);
        }


    }
}
