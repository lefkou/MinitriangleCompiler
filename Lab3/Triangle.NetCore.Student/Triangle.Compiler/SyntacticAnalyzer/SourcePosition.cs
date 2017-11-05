
namespace Triangle.Compiler.SyntacticAnalyzer {

    public class SourcePosition {

        public Location start, finish;

        public SourcePosition () {
            start = null;
            finish = null;
        }

        public SourcePosition (Location s, Location f) {
            start = s;
            finish = f;
        }

        public override string ToString() {
            return start + ", " + finish;
        }
    }
}