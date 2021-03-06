﻿//-------------------------------------------------------------------------
// 키アサイン
// 설정
//-------------------------------------------------------------------------
using System.Windows.Forms;

//-------------------------------------------------------------------------
namespace Utility.KeyAssign
{
	//-------------------------------------------------------------------------
	/// <summary>
	/// 키アサイン설정フォーム
	/// </summary>
	public partial class KeyAssignListForm : Form
	{
		private KeyAssiginSettingHelper		m_helper;

		/// <summary>
		/// OKボタンが押されたときの변경내용
		/// </summary>
		public KeyAssignList List			{	get{	return m_helper.List;	}}

		//-------------------------------------------------------------------------
		/// <summary>
		/// 구축
		/// </summary>
		/// <param name="assign_list">키アサイン목록</param>
		public KeyAssignListForm(KeyAssignList assign_list)
		{
			InitializeComponent();

			// カラムでのソート유효
			listView1.EnableSort(true);

			// ヘルパに任せる
			m_helper	= new KeyAssiginSettingHelper(	assign_list,
														this,
														comboBox1,
														listView1,
														button1, button4, button5);
		}
	}
}
