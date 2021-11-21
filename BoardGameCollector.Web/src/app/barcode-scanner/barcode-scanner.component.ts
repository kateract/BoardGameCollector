import { Component, OnInit, ViewChild, EventEmitter } from '@angular/core';
import { ZXingScannerComponent } from '@zxing/ngx-scanner';
import { BehaviorSubject } from 'rxjs';


@Component({
  selector: 'app-barcode-scanner',
  templateUrl: './barcode-scanner.component.html',
  styleUrls: ['./barcode-scanner.component.scss']
})
export class BarcodeScannerComponent implements OnInit {

  constructor() { }
  scannerEnabled: boolean = true;
  torchEnabled: boolean = false;
  torchAvailable$ = new BehaviorSubject<boolean>(false);
  desiredDevice: MediaDeviceInfo | undefined;
  deviceSelected: string = "";
  availableDevices: MediaDeviceInfo[] = [];
  resultString: string = "";
  
  public get hasDevices() : boolean {
    return this.availableDevices && this.availableDevices.length > 0;
  }
  
  
  @ViewChild('scanner') scanner: ZXingScannerComponent | undefined;

  ngOnInit(): void {
    
  }

  onCamerasFound(devices: MediaDeviceInfo[]): void{
    this.availableDevices = devices
  }

  onScanSuccess(resultString: string) {
    this.resultString = resultString;
    console.debug(this.resultString);
  }

  onDeviceChange(device: MediaDeviceInfo | undefined): void {
    const selectedStr = device?.deviceId || '';
    if(this.deviceSelected === selectedStr) { return;}
    this.deviceSelected = selectedStr;
    this.desiredDevice = device;
  }

  onTorchCompatible(isCompatible: boolean | undefined): void {
    this.torchAvailable$.next(isCompatible || false)
  }
}
