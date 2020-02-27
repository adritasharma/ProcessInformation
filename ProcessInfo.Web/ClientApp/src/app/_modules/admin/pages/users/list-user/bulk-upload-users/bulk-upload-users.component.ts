import { Component, OnInit } from '@angular/core';
import { UppyConfig } from 'src/app/_common/shared/models/UppyConfig';
import { environment } from 'src/environments/environment';
import { HttpService } from 'src/app/_common/core/services/http.service';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-bulk-upload-users',
  templateUrl: './bulk-upload-users.component.html',
  styleUrls: ['./bulk-upload-users.component.css']
})
export class BulkUploadUsersComponent implements OnInit {

  constructor(private http: HttpService) { }

  uploadErrorList: Array<string> = []
  savedCasesList: Array<any> = []

  ngOnInit() {
  }

  settings: UppyConfig = {
    uploadAPI: {
      endpoint: environment.apiUrl + 'files/Upload',
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('userToken')
      }
    },

    options: {
      Webcam: true
    },
    restrictions: {
      // maxFileSize: 1000000,
      maxNumberOfFiles: 2,
      // minNumberOfFiles: 1,
      // allowedFileTypes: ['image/*','pdf/*', 'docs/*']
    }
  }

  onFileAdd(evt) {
    console.log("onFileAdd", evt)
  }
  onFileUpload(evt) {
    console.log("onFileUpload", evt)
  }
  uploadResult(evt) {
    console.log("uploadResult", evt)
  }

  downloadSample() {
    this.http.getFile(environment.apiUrl + 'user/downloadSampleBulkUserUploadFile')
      .subscribe((resp: any) => {
        saveAs(resp, `sample-file.xlsx`)
      });
  }
}
