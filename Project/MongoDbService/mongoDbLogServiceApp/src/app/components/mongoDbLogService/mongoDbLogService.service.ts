import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, of, map} from 'rxjs';
import { environment } from '../../../environments/environment';


@Injectable({
    providedIn: 'root'
  })

  export class MongoDbLogService {

    constructor(
      private http : HttpClient
    ) { }
  
    private apiURL = environment.apiURL + '/mongoManagement'
  
    databaseInfo(): Observable<any>{
      return this.http.get<any>(`${this.apiURL}/databaseInfo`)
      .pipe(
        catchError(this.handleError<any>('databaseInfo')) // Handle errors
      )
    ;
    }

    collectionInfo(databaseName: string): Observable<any>{
        return this.http.get<any>(`${this.apiURL}/collectionInfo?databaseName=${databaseName}`)
        .pipe(
          catchError(this.handleError<any>('collectionInfo')) // Handle errors
        )
      ;
      }

    documentByUniTranId(databaseName: string, collectionName: string, uniqueTransID: string): Observable<any>{
      return this.http.get<any>(`${this.apiURL}/documentByUniTranId?databaseName=${databaseName}&collectionName=${collectionName}&uniTranId=${uniqueTransID}`)
      // .pipe(
      //   catchError(this.handleError<any>('documentByUniTranId')) // Handle errors
      // )
    ;
    }

    deleteDocumentByUniTranId(databaseName: string, collectionName: string, uniqueTransID: string): Observable<any>{
      return this.http.delete(`${this.apiURL}/removeDocumentByUniTranId?databaseName=${databaseName}&collectionName=${collectionName}&uniTranId=${uniqueTransID}`)
      .pipe(
        catchError(this.handleError<any>('deleteDocumentByUniTranId')) // Handle errors
      )
    ;
    }      

    uploadDocument(formData: FormData): Observable<any>{
      return this.http.post<any>(`${this.apiURL}/uploadDocument`, formData);
    }

    private handleError<T>(operation = 'operation', result?: any) {
        return (error: any): Observable<any> => {
          console.error(error); 
          return of(result as any || { message: `Failed to retrieve data from ${operation}` });
        };
    }
  }

