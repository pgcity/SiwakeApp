﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiwakeApp {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class PCLResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PCLResource() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SiwakeApp.PCLResource", typeof(PCLResource).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   [
        ///  {
        ///    &quot;SetName&quot;: &quot;問題集1&quot;,
        ///    &quot;Grade&quot;: &quot;3級&quot;,
        ///    &quot;Description&quot;: &quot;問題集1です&quot;,
        ///    &quot;Questions&quot;: [
        ///      {
        ///        &quot;Description&quot;: &quot;商品を450円で仕入れ、他社から受けた約束手形を裏書譲渡した。&quot;,
        ///        &quot;Hint&quot;: &quot;約束手形をもらっているので「受取手形」がすでにある！&quot;,
        ///        &quot;Commentary&quot;: &quot;仕入に対して、以前受け取っていた約束手形→受取手形を減らします。&quot;,
        ///        &quot;UseOffsetAnswer&quot;: false,
        ///        &quot;SiwakeList&quot;: [
        ///          {
        ///            &quot;Kamoku&quot;: &quot;仕入&quot;,
        ///            &quot;Money&quot;: 450,
        ///            &quot;isKari&quot;: true
        ///          },
        ///          {
        ///            &quot;Kamoku&quot;: &quot;受取手形&quot;,
        ///            &quot;Money&quot;:  [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Questions {
            get {
                return ResourceManager.GetString("Questions", resourceCulture);
            }
        }
    }
}
