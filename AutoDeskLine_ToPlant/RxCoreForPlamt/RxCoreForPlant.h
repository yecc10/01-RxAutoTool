// RxCoreForPlamt.h : RxCoreForPlamt DLL ����ͷ�ļ�
//

#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"		// ������


// CRxCoreForPlamtApp
// �йش���ʵ�ֵ���Ϣ������� RxCoreForPlamt.cpp
//

class CRxCoreForPlamtApp : public CWinApp
{
public:
	CRxCoreForPlamtApp();

// ��д
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
