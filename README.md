# CDS Tracker

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![Open Source](https://badges.frapsoft.com/os/v1/open-source.svg?v=103)](https://github.com/ellerbrock/open-source-badges/)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](https://github.com/okekevicktur/CDSProject/pulls)

**An open-source biometric attendance software for NYSC Community Development Service (CDS) groups.**

Built in **2020 during NYSC service year** after seeing how hard it was to keep honest, reliable CDS attendance records with paper registers and manual roll calls. CDS Tracker replaces that process with fingerprint verification, passport capture, and printable monthly reports.

> *“It takes biometric records of corps members’ attendance in their CDS groups.”*  
> — PiedTech Solution · Copyright © 2020 · Trademark: **CDSTracker**

---

## The problem it solves

During NYSC, CDS groups often rely on paper attendance. That opens the door to:

- Buddy signing / proxy attendance  
- Lost or incomplete registers  
- Slow monthly reporting for Zonal / Local Government Inspectors  
- No clear month-by-month participation percentage  

CDS Tracker was built on the ground to close those gaps for a CDS group: enroll once with biometrics, verify in seconds on meeting days, and export attendance as PDF.

---

## Features

### Corps member registration
- Capture full biodata: name, surname, other names, state code, call-up number, phone, batch, stream, and service year  
- Passport photograph via **webcam** (OpenCV) or file upload  
- Photos stored under `C:\CDSAttendance\CorpsMembers\`  
- Duplicate checks on state code / call-up number  

### Fingerprint enrollment & verification
- DigitalPersona **One Touch SDK** fingerprint capture  
- Multi-sample enrollment stored in SQLite as templates  
- Live verification on CDS meeting days  
- Guards against double attendance on the same day  
- Soft monthly cap (up to 3 recorded CDS attendances per month, then admin review)  

### Live attendance portal
- Roll-call style list of all registered corps members  
- Verified members highlight in green  
- On-screen identity card after a match (photo + biodata)  
- Daily summary: *“X of Y candidates verified”*  
- Optional lookup by state code or call-up number  

### Reports & PDF export
- **Monthly report** — attendance percentage for a selected month  
- **General report** — Jan–Dec percentages per corps member  
- Search by name or state code  
- Export to **PDF** (iTextSharp) for inspectors and CDS executives  

### Accounts & roles
- First user can become **Admin**  
- Up to **2 User** accounts plus Admin  
- Admin panel to view and remove accounts (with confirmation for Admin deletion)  
- “Remember me” login option  

### Practical NYSC touches
- Splash screen on launch  
- System time / timezone check (UTC+01 West Central Africa) so attendance dates stay consistent  
- Desktop Windows Forms UI with Bunifu controls  

---

## Tech stack

| Layer | Technology |
|--------|------------|
| Platform | Windows desktop (WinForms) |
| Language | C# · .NET Framework 4.5 |
| Database | SQLite (`CDSDB.db`) |
| Biometrics | DigitalPersona One Touch SDK (.NET) |
| Camera | OpenCvSharp 3 |
| PDF | iTextSharp |
| UI | Bunifu UI + Windows Forms |

**Solution:** `CDSProject.sln`  
**Main project:** `CDSProject/`

---

## Hardware & software requirements

### Required
- Windows 7 / 8 / 10 / 11 (x86 or x64)  
- [.NET Framework 4.5+](https://dotnet.microsoft.com/download/dotnet-framework)  
- SQLite runtime (ships with the NuGet packages in `packages/`)  

### For biometrics
- A DigitalPersona-compatible fingerprint reader  
- DigitalPersona One Touch SDK (.NET) installed, with these assemblies available to the project:  
  `DPFPDevNET`, `DPFPEngNET`, `DPFPGuiNET`, `DPFPShrNET`, `DPFPVerNET`

### Optional
- Webcam for live passport capture  

---

## Getting started

### 1. Clone the repository

```bash
git clone https://github.com/okekevicktur/CDSProject.git
cd CDSProject
```

### 2. Restore packages & fix local DLL paths

Open `CDSProject.sln` in **Visual Studio 2017+** (or later with .NET Framework targeting packs).

NuGet packages under `packages/` should restore automatically. Several references in `CDSProject.csproj` currently point to machine-specific paths (Bunifu, DigitalPersona, iTextSharp). Update those `HintPath` values (or copy the DLLs into a `libs/` folder and retarget) before building on a new machine.

Also update the SQLite connection string wherever it still points at an absolute path such as:

```text
C:\Users\Pipper\source\repos\CDSProject\CDSDB.db
```

Prefer a relative / `|DataDirectory|` path (as already used in `LoginForm`) so the app runs from any install location.

### 3. Place the database

Ensure `CDSDB.db` sits next to the executable (or at the path your connection string expects). Typical tables include:

- `logDetail` — usernames, passwords, roles  
- `CorpData` — corps member biodata & passport path  
- `fingerPrint` — enrolled biometric templates  
- `TransactAttendance` — daily / monthly attendance counters  

### 4. Build & run

1. Set **CDSProject** as the startup project  
2. Build **Debug** or **Release**  
3. Run `CDSProject.exe`  
4. Register the first **Admin** account, then enroll corps members and start verification  

---

## Typical workflow

```text
Register Admin / Users
        ↓
Enroll corps members (biodata + photo + fingerprint)
        ↓
On CDS day → open Attendance Portal → Start scanner
        ↓
Corps member fingerprints → verified & logged
        ↓
Generate monthly / general report → export PDF
```

---

## Project structure

```text
CDSProject/
├── CDSProject.sln
├── CDSDB.db                 # SQLite attendance database
├── packages/                # NuGet dependencies
└── CDSProject/
    ├── Program.cs           # Entry point + splash thread
    ├── FormSplashScreen.*   # Launch splash
    ├── LoginForm.*          # Sign-in
    ├── RegisterForm.*       # First-time Admin / User signup
    ├── MainPage.*           # Shell / navigation
    ├── UCRegisterCorpMember.*   # Enroll corps + fingerprint + camera
    ├── UcCDSVerifier.*          # Live biometric attendance
    ├── UcCDSReport.*            # Monthly / general reports + PDF
    ├── Admin Account Panel.*    # Account management
    ├── FormAdminConfirm.*       # Confirm admin deletion
    ├── SystemTimeChecker.*      # Timezone sanity check
    ├── ClearUtilities.cs
    └── Properties/
```

---

## Screenshots

> Add screenshots here before publishing (login, registration, attendance portal, reports).

| Screen | Description |
|--------|-------------|
| Login | Secure sign-in with optional “Remember me” |
| Register Corp Member | Biodata, webcam/upload, fingerprint enrollment |
| Attendance Portal | Live verification + roll call highlighting |
| Reports | Monthly % and Jan–Dec general report with PDF export |

---

## Security notes (important before going public)

This is a 2020 desktop prototype built for a real CDS need. Before wide public use, be aware:

- Passwords are stored in plain text in SQLite — **hash them** before production use  
- Several queries use string concatenation — migrate to **parameterized queries** everywhere  
- Absolute DB paths and signed ClickOnce keys (`CDSProject_TemporaryKey.pfx`) should not be committed if you want a clean public repo  
- Prefer excluding local databases with personal corps member data from the public repository  

A sensible `.gitignore` for a public release should include at least:

```gitignore
bin/
obj/
.vs/
*.user
*.suo
*.pfx
CDSDB.db
**/CDSAttendance/
```

---

## Roadmap ideas

- Relative DB path + portable install folder  
- Password hashing (e.g. PBKDF2 / bcrypt)  
- Cloud / multi-LGA sync for Zonal Inspectors  
- Modern UI refresh  
- Optional phone OTP / QR fallback when scanners are unavailable  

---

## Origin story

Created in **2020 during NYSC** by a corps member who watched CDS attendance struggle under paper processes. The goal was simple: make attendance **fast, fair, and auditable** for CDS executives and inspectors — without buddy signing.

Built under **PiedTech Solution** as **CDSTracker**.

---

## Contributing

Contributions are warmly welcomed! As an open-source project, community involvement helps make CDS Tracker more reliable, secure, and accessible to CDS groups across Nigeria.

Areas where help is especially appreciated:

- Removing hard-coded machine paths & ensuring seamless relative database paths  
- Hardening authentication (password hashing e.g. BCrypt/PBKDF2) & migrating to parameterized SQL  
- Modernizing UI components and cleaning up legacy dependencies  
- Creating clean build scripts and portable installers  
- Documentation, testing, and UI screenshots  

### How to contribute:
1. Fork the repository  
2. Create a feature branch (`git checkout -b feature/improvement-name`)  
3. Commit your changes (`git commit -m 'Add improvement'`)  
4. Push to your branch (`git push origin feature/improvement-name`)  
5. Open a Pull Request  

---

## License

This project is open-source software licensed under the [MIT License](LICENSE).

```text
MIT License
Copyright (c) 2020 PiedTech Solution
```

You are free to use, modify, fork, and distribute this software in accordance with the MIT License conditions. See the [LICENSE](LICENSE) file for complete details.

---

## Acknowledgments

- NYSC CDS executives and corps members who inspired the workflow  
- DigitalPersona One Touch SDK  
- OpenCvSharp, SQLite, iTextSharp, and Bunifu UI communities  
