// RxCoreForPlant.h : RxCoreForPlant DLL ����ͷ�ļ�
//

#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"		// ������


// CRxCoreForPlantApp
// �йش���ʵ�ֵ���Ϣ������� RxCoreForPlant.cpp
//

class CRxCoreForPlantApp : public CWinApp
{
public:
	CRxCoreForPlantApp();

// ��д
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
