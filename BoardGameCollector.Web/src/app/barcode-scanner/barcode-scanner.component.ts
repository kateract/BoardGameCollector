import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { BarcodeScannerLivestreamComponent } from 'ngx-barcode-scanner';

@Component({
  selector: 'app-barcode-scanner',
  templateUrl: './barcode-scanner.component.html',
  styleUrls: ['./barcode-scanner.component.scss']
})
export class BarcodeScannerComponent implements AfterViewInit {
  @ViewChild(BarcodeScannerLivestreamComponent) barcodeScanner: BarcodeScannerLivestreamComponent | undefined
  
  barcodeTypes: string[] = [
    'ean', 'upc'
  ]
  scanBuffer: Map<string, number> = new Map<string, number>();
  scannedCodes: string[] = [];
  devices: MediaDeviceInfo[] = [];

  ngAfterViewInit(): void {
    navigator.mediaDevices.enumerateDevices().then((mediaDevices: MediaDeviceInfo[]) => {
      console.log(mediaDevices);
      mediaDevices.map(device => {
        if (device.kind === "videoinput") {
          this.devices.push(device);
          
        }
      })
      if(this.devices.length <= 0) return;
      let preferredDeviceId = localStorage.getItem("preferredDevice");
      
      if(!preferredDeviceId) {
        preferredDeviceId = this.devices.find(d => d.label.includes('0') || d.label.includes("Logitech"))?.deviceId || null
      }

      if (!preferredDeviceId) {
        preferredDeviceId = this.devices[0].deviceId
      }
      
  
      if (this.barcodeScanner) {
        this.barcodeScanner.deviceId = preferredDeviceId;
        this.barcodeScanner
      }
      this.barcodeScanner?.start();
    });
  }


  onValueChanges(result: any) {
    let barcodeValue = result.codeResult.code
    this.scanBuffer.set(barcodeValue, (this.scanBuffer.get(barcodeValue) || 0) + 1)
    this.scanBuffer.forEach((count, barcode) => {
      if(count > 3) {
        this.addCode(barcode);
        this.scanBuffer.clear();
      }
    })
  }

  addCode(barcode: string) {
    if(!this.scannedCodes.includes(barcode)) {
      this.scannedCodes.push(barcode);
      console.log(barcode);
    }
  }

  onStarted(): void {
    console.log('started');
  }



}
