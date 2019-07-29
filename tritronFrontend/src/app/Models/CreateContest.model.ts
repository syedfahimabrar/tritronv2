import {Time} from '@angular/common';

export class CreateContestModel {
    Name:string;
    StartDate:string;
    EndDate:string;
    BackgroundImage:string;
    Description:string;
    AllowedLanguage:[string];
    Problems;
}
