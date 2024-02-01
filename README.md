# QR Code Scanner and Generator

This C# Windows Forms Application demonstrates a simple QR code scanner and generator using AForge.NET and MessagingToolkit libraries.

## Features

### QR Code Scanner (Form1)
- Utilizes AForge.NET library for accessing and displaying video from the webcam.
- Uses ZXing library for real-time decoding of QR codes.
- Allows users to select a webcam device from the available options.
- Displays the captured webcam frames in a PictureBox.
- Decodes QR codes from the webcam feed and displays the result in a TextBox.

### QR Code Generator (Form2)
- Utilizes MessagingToolkit library for generating QR codes.
- Allows users to enter text in a TextBox and generate a corresponding QR code.
- Displays the generated QR code in a PictureBox.

## How to Use

1. **QR Code Scanner:**
   - Launch the application and select a webcam device from the dropdown.
   - Click the "Start Camera" button to begin capturing frames from the selected webcam.
   - Click the "Decode QR Code" button to start decoding QR codes in real-time.
   - The decoded QR code information will be displayed in the TextBox.

2. **QR Code Generator:**
   - Click the "Generate QR Code" button.
   - Enter the desired text in the TextBox.
   - The corresponding QR code will be generated and displayed in the PictureBox.

## Dependencies
- AForge.NET: [AForge.NET GitHub](https://github.com/andrewkirillov/AForge.NET)
- ZXing.Net: [ZXing.Net GitHub](https://github.com/micjahn/ZXing.Net)
- MessagingToolkit.QRCode: [MessagingToolkit GitHub](https://github.com/micjahn/MessagingToolkit)

## Notes
- Make sure to stop the camera before closing the application to avoid issues.

Feel free to explore and modify the code for your own projects!
