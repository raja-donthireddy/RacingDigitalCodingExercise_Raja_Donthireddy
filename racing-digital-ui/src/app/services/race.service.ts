import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RaceResult } from '../models/race-result.model';

@Injectable({
  providedIn: 'root'
})
export class RaceService {
  private apiUrl= '';

  constructor(private http: HttpClient) {}

  getAll(): Observable<RaceResult[]> {
    return this.http.get<RaceResult[]>(this.apiUrl);
  }

  updateNote(id: number, note: string): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/${id}/note`, { note });
  }
}
