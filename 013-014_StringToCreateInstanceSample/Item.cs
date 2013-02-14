
namespace Sample {
    public class Item {

        private int _id;
        
        // 引数なし
        public Item() {
            _id = -1; // ID無し
        }

        // 引数あり
        public Item(int id) {
            _id = id;
        }

        // IDを返す
        public int GetID() {
            return _id;
        }
    }
}
