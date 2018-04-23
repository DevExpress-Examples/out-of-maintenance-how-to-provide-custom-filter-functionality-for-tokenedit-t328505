using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Popup;
using System.Collections;

namespace T328505 {
    [UserRepositoryItem("RegisterMyTokenEdit")]
    public class RepositoryItemMyTokenEdit : RepositoryItemTokenEdit {
        static RepositoryItemMyTokenEdit() {
            RegisterMyTokenEdit();
        }

        private EventHandler<MyFilterEventArgs> customFilterHandler;
        private bool _UseCustomFilter;

        public bool UseCustomFilter {
            get { return _UseCustomFilter; }
            set {
                _UseCustomFilter = value;
            }
        }

        public EventHandler<MyFilterEventArgs> CustomFilterTokens {
            get {
                return customFilterHandler;
            }
            set {
                customFilterHandler = value;
            }
        }

        public const string CustomEditName = "MyTokenEdit";

        public RepositoryItemMyTokenEdit() {
        }

        public override string EditorTypeName {
            get {
                return CustomEditName;
            }
        }

        public static void RegisterMyTokenEdit() {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(MyTokenEdit), typeof(RepositoryItemMyTokenEdit), typeof(MyTokenEditViewInfo), new TokenEditPainter(), true, img));
        }

        public override void Assign(RepositoryItem item) {
            BeginUpdate();
            try {
                base.Assign(item);
                RepositoryItemMyTokenEdit source = item as RepositoryItemMyTokenEdit;
                if(source == null) return;
                this.UseCustomFilter = source.UseCustomFilter;
                this.CustomFilterTokens = source.CustomFilterTokens;
                //
            }
            finally {
                EndUpdate();
            }
        }

        internal void OnCustomFilterText(MyFilterEventArgs args) {
            if(customFilterHandler != null) {
                customFilterHandler(this, args);
            }
        }
    }

    [ToolboxItem(true)]
    public class MyTokenEdit : TokenEdit {
        internal void OnCustomFilterText(MyFilterEventArgs args) {
            this.Properties.OnCustomFilterText(args);
        }

        static MyTokenEdit() {
            RepositoryItemMyTokenEdit.RegisterMyTokenEdit();
        }

        public MyTokenEdit() {
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMyTokenEdit Properties {
            get {
                return base.Properties as RepositoryItemMyTokenEdit;
            }
        }

        public override string EditorTypeName {
            get {
                return RepositoryItemMyTokenEdit.CustomEditName;
            }
        }

        protected override TokenEditPopupForm CreatePopupForm() {
            return new MyTokenEditPopupForm(this);
        }

        protected override BaseTokenEditPopupController CreatePopupController() {
            if(Properties.EditMode == TokenEditMode.TokenList || Properties.EditMode == TokenEditMode.Default) return new MyTokenEditTokenListPopupController(this);
            return new TokenEditManualModePopupController(this);
        }
    }
    public class MyTokenEditViewInfo : TokenEditViewInfo {
        public MyTokenEditViewInfo(RepositoryItem item)
            : base(item) {
        }
    }

    public class MyTokenEditPopupForm : TokenEditPopupForm {
        public MyTokenEditPopupForm(TokenEdit edit)
            : base(edit) {
        }

        protected override ITokenEditDropDownControl CreateDropDownControl() {
            MyDefaultTokenEditDropDownControl control = new MyDefaultTokenEditDropDownControl();
            return control;
        }
    }

    public class MyDefaultTokenEditDropDownControl : DefaultTokenEditDropDownControl {
        public MyDefaultTokenEditDropDownControl()
            : base() {
        }

        private IList GetCustomFilterSourceCore() {
            TokenEditTokenCollection tokCol = Properties.Tokens;
            TokenEditSelectedItemCollection selCol = Properties.SelectedItems;
            if(selCol.Count == 0) return tokCol;
            HashSet<int> indices = new HashSet<int>();
            for(int i = 0; i < selCol.Count; i++) {
                TokenEditToken tok = selCol[i];
                indices.Add(Properties.Tokens.IndexOf(tok));
            }
            List<TokenEditToken> list = new List<TokenEditToken>(tokCol.Count);
            for(int i = 0; i < tokCol.Count; i++) {
                if(indices.Contains(i)) continue;
                list.Add(tokCol[i]);
            }
            return list;
        }

        private IList GetCustomFilterSource() {
            IList list = GetCustomFilterSourceCore();
            List<TokenEditToken> newList = new List<TokenEditToken>();
            MyTokenEdit edit = this.OwnerEdit as MyTokenEdit;
            for(int i = 0; i < list.Count; i++) {
                MyFilterEventArgs args = new MyFilterEventArgs(list[i] as TokenEditToken);
                edit.OnCustomFilterText(args);
                if(args.IsValidToken) {
                    newList.Add(list[i] as TokenEditToken);
                }
            }
            return newList;
        }

        public override void SetDataSource(object obj) {
            if(((OwnerEdit as MyTokenEdit).Properties as RepositoryItemMyTokenEdit).UseCustomFilter)
                base.SetDataSource(GetCustomFilterSource());
            else
                base.SetDataSource(obj);
        }
    }

    public class MyTokenEditTokenListPopupController : TokenEditTokenListPopupController {
        public MyTokenEditTokenListPopupController(TokenEdit edit)
            : base(edit) {
        }
        public override void UpdateFilter(string filter) {
            if(((OwnerEdit as MyTokenEdit).Properties as RepositoryItemMyTokenEdit).UseCustomFilter)
                filter = string.Empty;
            base.UpdateFilter(filter);
        }
    }

    public class MyFilterEventArgs : EventArgs {
        // Fields...
        private bool _IsValidToken;
        private TokenEditToken _Token;
        public TokenEditToken Token {
            get { return _Token; }
            set {
                _Token = value;
            }
        }

        public bool IsValidToken {
            get { return _IsValidToken; }
            set {
                _IsValidToken = value;
            }
        }

        public MyFilterEventArgs(TokenEditToken token) {
            this.Token = token;
            IsValidToken = true;
        }
    }
}
