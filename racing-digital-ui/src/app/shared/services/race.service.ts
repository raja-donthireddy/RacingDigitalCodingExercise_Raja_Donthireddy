import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Race } from '../../shared/models/race.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RaceService {
  constructor(private http: HttpClient) {}

  getAllRaces(): Observable<Race[]> {
    return this.http.get<Race[]>('/api/RaceResults');
  }

  getRace(id: string): Observable<Race> {
    return this.http.get<Race>(`/api/RaceResults/${id}`);
  }

  updateNote(id: string, note: string): Observable<void> {
    return this.http.post<void>(`/api/RaceResults/${id}/note`, {note});
  }
}