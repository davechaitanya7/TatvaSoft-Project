import { Injectable } from '@angular/core';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { City, CMS, Country, Mission } from '../model/cms.model';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { MissionApplication } from '../model/missionApplication.model';
import { MissionTheme } from '../model/missionTheme.model';
import { MissionSkill } from '../model/missionSkill.model';
@Injectable({
  providedIn: 'root',
})
export class AdminsideServiceService {
  constructor(
    public http: HttpClient,
    public toastr: ToastrService,
    public router: Router
  ) {}
  // apiUrl:string='http://localhost:63943/api';
  apiUrl: string = 'http://localhost:5140/api/Login';
  imageUrl: string = 'http://localhost:56577';

  //User
  UserList(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/UserDetailList`);
  }
  DeleteUser(userId: any) {
    return this.http.delete(
      `${this.apiUrl}/DeleteUserAndUserDetail/${userId}`
    );
  }

  //CMS
  CMSList(): Observable<CMS[]> {
    return this.http.get<CMS[]>(`${this.apiUrl1}/CMS/CMSList`);
  }
  CMSDetailById(id: number): Observable<CMS[]> {
    return this.http.get<CMS[]>(`${this.apiUrl1}/CMS/CMSDetailById/${id}`);
  }
  AddCMS(data: CMS) {
    return this.http.post(`${this.apiUrl1}/CMS/AddCMS`, data, {
      responseType: 'json',
    });
  }
  UpdateCMS(data: CMS) {
    return this.http.post(`${this.apiUrl1}/CMS/UpdateCMS`, data);
  }
  DeleteCMS(data: any) {
    return this.http.delete(`${this.apiUrl1}/CMS/DeleteCMS/${data}`);
  }

  //Mission
  GetMissionThemeList():Observable<MissionTheme[]>{
    return this.http.get<MissionTheme[]>(`${this.apiUrl1}/Common/GetMissionTheme`);
  }
  GetMissionSkillList():Observable<MissionSkill[]>{
    return this.http.get<MissionSkill[]>(`${this.apiUrl1}/Common/GetMissionSkill`);
  }
  UploadImage(data: any) {
    return this.http.post(`${this.apiUrl1}/Mission/UploadImage`,data);
  }
  UploadDoc(data: any) {
    return this.http.post(`${this.apiUrl1}/Mission/UploadDocumnets`,data);
  }
  MissionList(): Observable<Mission[]> {
    return this.http.get<Mission[]>(`${this.apiUrl1}/Mission/MissionList`);
  }
  MissionDetailById(id: number): Observable<Mission[]> {
    return this.http.get<Mission[]>(
      `${this.apiUrl1}/Mission/MissionDetailById/${id}`
    );
  }
  CountryList(): Observable<Country[]> {
    return this.http.get<Country[]>(`${this.apiUrl1}/Common/CountryList`);
  }
  CityList(countryId: any): Observable<City[]> {
    return this.http.get<City[]>(`${this.apiUrl1}/Common/CityList/${countryId}`);
  }
  AddMission(data: Mission) {
    return this.http.post(`${this.apiUrl1}/Mission/AddMission`, data);
  }
  UpdateMission(data: Mission) {
    return this.http.post(`${this.apiUrl1}/Mission/UpdateMission`, data);
  }
  DeleteMission(data: any) {
    return this.http.delete(`${this.apiUrl1}/Mission/DeleteMission/${data}`);
  }

  //Mission Application
  MissionApplicationList(): Observable<MissionApplication[]> {
    return this.http.get<MissionApplication[]>(
      `${this.apiUrl1}/AdminUser/MissionApplicationList`
    );
  }

  MissionApplicationDelete(data: MissionApplication){
    return this.http.post(`${this.apiUrl1}/Mission/MissionApplicationDelete`, data);
  }

  MissionApplicationApprove(missionApplicationId:any){
    return this.http.get(`${this.apiUrl1}/Mission/MissionApplicationApprove${missionApplicationId}}`);
  }

  //Mission Theme
  MissionThemeList(): Observable<MissionTheme[]> {
    return this.http.get<MissionTheme[]>(
      `${this.apiUrl1}/MissionTheme/GetMissionThemeList`
    );
  }
  MissionThemeById(id: any): Observable<MissionTheme[]> {
    return this.http.get<MissionTheme[]>(
      `${this.apiUrl1}/MissionTheme/GetMissionThemeById/${id}`
    );
  }
  AddMissionTheme(data: MissionTheme) {
    return this.http.post(`${this.apiUrl1}/MissionTheme/AddMissionTheme`, data);
  }
  UpdateMissionTheme(data: MissionTheme) {
    return this.http.post(
      `${this.apiUrl1}/MissionTheme/UpdateMissionTheme`,
      data
    );
  }
  DeleteMissionTheme(data: any) {
    return this.http.delete(
      `${this.apiUrl1}/MissionTheme/DeleteMissionTheme/${data}`
    );
  }

  apiUrl1: string = 'http://localhost:5140/api';
  //Mission Skill
  MissionSkillList(): Observable<MissionSkill[]> {
    return this.http.get<MissionSkill[]>(
      `${this.apiUrl1}/MissionSkill/GetMissionSkillList`
    );
  }
  MissionSkillById(id: any): Observable<MissionSkill[]> {
    return this.http.get<MissionSkill[]>(
      `${this.apiUrl1}/MissionSkill/GetMissionSkillById/${id}`
    );
  }
  AddMissionSkill(data: MissionSkill) {
    return this.http.post(`${this.apiUrl1}/MissionSkill/AddMissionSkill`, data);
  }
  UpdateMissionSkill(data: MissionSkill) {
    return this.http.post(
      `${this.apiUrl1}/MissionSkill/UpdateMissionSkill`,
      data
    );
  }
  DeleteMissionSkill(data: any) {
    return this.http.delete(
      `${this.apiUrl1}/MissionSkill/DeleteMissionSkill/${data}`
    );
  }
}
