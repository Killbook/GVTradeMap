﻿/*-------------------------------------------------------------------------

 ユニークな文字列
 空な文字列は追加されない

---------------------------------------------------------------------------*/

/*-------------------------------------------------------------------------
 using
---------------------------------------------------------------------------*/
using System.Collections.Generic;

/*-------------------------------------------------------------------------
 
---------------------------------------------------------------------------*/
namespace useful
{
	/*-------------------------------------------------------------------------
 
	---------------------------------------------------------------------------*/
	public class unique_string
	{
		private const int				MAX		= 20;
		private const int				MIN		= 1;

		private List<string>			m_strings;			// 重複しない文字列リスト
		private int						m_max;				// 保持する最大
	
		/*-------------------------------------------------------------------------
		 
		---------------------------------------------------------------------------*/
		public List<string> strings		{		get{	return m_strings;		}}
		public int max					{		get{	return m_max;			}
												set{	m_max	= value;
														if(m_max < MIN)	m_max	= MIN;}}

		/*-------------------------------------------------------------------------
		 
		---------------------------------------------------------------------------*/
		public unique_string()
		{
			m_strings		= new List<string>();
			m_max			= MAX;
		}

		/*-------------------------------------------------------------------------
		 追加
		 追加されたらtrueを返す
		---------------------------------------------------------------------------*/
		public bool Add(string str)
		{
			if(has_string(str)){
				// 削除する
				m_strings.Remove(str);
			}
			// 先頭に追加
			m_strings.Insert(0, str);

			// 最大数に収まるように調整する
			while(m_strings.Count > m_max){
				m_strings.RemoveAt(m_strings.Count -1);
			}
			return true;
		}

		/*-------------------------------------------------------------------------
		 追加
		 最後に追加される
		 追加されたらtrueを返す
		 設定ファイルからの読み込み用
		---------------------------------------------------------------------------*/
		public bool AddLast(string str)
		{
			if(has_string(str)){
				// 削除する
				m_strings.Remove(str);
			}
			// 先頭に追加
			m_strings.Add(str);

			// 最大数に収まるように調整する
			while(m_strings.Count > m_max){
				m_strings.RemoveAt(m_strings.Count -1);
			}
			return true;
		}

		/*-------------------------------------------------------------------------
		 含まれるかどうかを得る
		---------------------------------------------------------------------------*/
		private bool has_string(string str)
		{
			foreach(string s in m_strings){
				if(s == str)	return true;	// 含まれる
			}
			return false;
		}
	
		/*-------------------------------------------------------------------------
		 全て削除
		---------------------------------------------------------------------------*/
		public void Clear()
		{
			m_strings.Clear();
		}

		/*-------------------------------------------------------------------------
		 複製
		---------------------------------------------------------------------------*/
		public void Clone(unique_string list)
		{
			Clear();
			max		= list.max;
			foreach(string str in list.strings){
				m_strings.Add(str);
			}
		}
	}
}