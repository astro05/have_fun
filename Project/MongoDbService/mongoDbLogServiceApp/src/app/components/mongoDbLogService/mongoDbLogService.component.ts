import { Component, OnInit } from '@angular/core';
import { MongoDbLogService } from './mongoDbLogService.service';
import { CommonModule } from '@angular/common';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule} from '@angular/forms';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { NgxJsonViewerModule } from 'ngx-json-viewer';

@Component({
  selector: 'app-mongoDbLogService',
  standalone: true,
  imports: [FormsModule,
            CommonModule, 
            MatFormFieldModule, 
            MatSelectModule, 
            MatInputModule, 
            MatButtonModule, 
            MatDividerModule, 
            MatIconModule,
            NgxJsonViewerModule,],
  templateUrl: './mongoDbLogService.component.html',
  styleUrl: './mongoDbLogService.component.css'
})
export class MongoDbLogServiceComponent implements OnInit{
  
  databaseName: string = "";
  collectionName: string = "";
  uniqueTransID: string = "";
  document: string = "";
  databases: string[] = [];
  collections: string[] = [];
  selectedFile: File | undefined;
 
  constructor(
    private mongoDbLogService : MongoDbLogService
  ){}

  ngOnInit(): void {
    this.loadDatabaseInfo();
  }

  loadDatabaseInfo(){
    this.mongoDbLogService.databaseInfo().subscribe({
      next: (value: any) => {
        this.databases = value;
      },
      error: (err: any) => {
        console.error(err);
      },
      complete: () => {
       // console.log('Observable completed!');
      },
    });
  }

  loadCollectionInfo(){
    this.mongoDbLogService.collectionInfo(this.databaseName).subscribe({
      next: (value: any) => {
        this.collections = value;
      },
      error: (err: any) => {
        console.error(err);
      },
      complete: () => {
       // console.log('Observable completed!');
      },
    });
  }

  loadDocumentByUniTranId(){
    this.mongoDbLogService.documentByUniTranId(this.databaseName, this.collectionName, this.uniqueTransID).subscribe({
      next: (value: any) => {
        this.document = value;
        if(value == null)
          alert("No data found.");
      },
      error: (err: any) => {
        alert("Failed to load data.");
      },
      complete: () => {
        //console.log("console: "+this.document);
      }
    });
  }
  
  downloadJson(){
    if(this.document != "")
    {
      this.dyanmicDownloadByHtmlTag({
        fileName: `${this.databaseName}_${this.collectionName}_${this.uniqueTransID}.json`,
        text: JSON.stringify(this.document)
      });
    }
    else
    {
      alert("Failed to download data.");
    }
  }

  deleteDocumentByUniTranId(){
    this.downloadJson();

    this.mongoDbLogService.deleteDocumentByUniTranId(this.databaseName, this.collectionName, this.uniqueTransID).subscribe({
      next: (value: any) => {
        this.document = "";
        alert("Delete Successful.");
      },
      error: (err: any) => {
        alert("Failed to delete data.");
      },
      complete: () => {
       // console.log('Observable completed!');
      }
    })
  }  

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];
  }

  uploadFile(): void {
    if (!this.databaseName || !this.collectionName || !this.selectedFile) {
      alert('Please fill in all fields and select a file.');
      return;
    }

    const formData = new FormData();
    formData.append('databaseName', this.databaseName);
    formData.append('collectionName', this.collectionName);
    formData.append('file', this.selectedFile);


    this.mongoDbLogService.uploadDocument(formData).subscribe({
      next: (value: any) => {
        this.selectedFile = undefined;  
        alert('File uploaded successfully.');
      },
      error: (err: any) => {
        alert('Error uploading file. Please try again.');
      },
      complete: () => {
       // console.log('Observable completed!');
      }
    })
  }
  
  private setting = {
    element: {
      dynamicDownload: null as unknown as HTMLElement
    }
  }
  
  private dyanmicDownloadByHtmlTag(arg: {
    fileName: string,
    text: string
  }) {
    if (!this.setting.element.dynamicDownload) {
      this.setting.element.dynamicDownload = document.createElement('a');
    }
    const element = this.setting.element.dynamicDownload;
    const fileType = arg.fileName.indexOf('.json') > -1 ? 'text/json' : 'text/plain';
    element.setAttribute('href', `data:${fileType};charset=utf-8,${encodeURIComponent(arg.text)}`);
    element.setAttribute('download', arg.fileName);

    var event = new MouseEvent("click");
    element.dispatchEvent(event);
  }

}
