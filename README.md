# WindowsUpdateAgent

##	Yêu cầu
```
	Server đã bật dịch vụ và có thể kết nối đến dịch vụ Windows Update của Microsoft
```

##	Cài đặt
```
	Chạy CMD bằng quyền admin
```

```
	Từ thư mục WindowsUpdateAgent
	cd "WindowsUpdateAgent_Net4.5\bin\Debug"
```

```
	Thực thi lệnh cài đặt
	C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe WindowsUpdateAgent.exe
```

##	Gỡ cài đặt

```
	C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe /u WindowsUpdateAgent.exe
```

```
	Lưu ý: Cần kiểm tra đường dẫn C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe trên server
	trước khi thực thi câu lệnh để lấy đường dẫn đúng của file "InstallUtil.exe"
```
