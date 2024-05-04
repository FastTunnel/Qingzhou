/* tslint:disable */
/* eslint-disable */
/**
 * 轻舟 RestAPI
 * An ASP.NET Core Web API for managing ToDo items
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import type { AddTeamResponse } from './AddTeamResponse';
import {
    instanceOfAddTeamResponse,
    AddTeamResponseFromJSON,
    AddTeamResponseFromJSONTyped,
    AddTeamResponseToJSON,
} from './AddTeamResponse';

/**
 * @type QzResponseOfAddTeamResponseData
 * 
 * @export
 */
export type QzResponseOfAddTeamResponseData = AddTeamResponse;

export function QzResponseOfAddTeamResponseDataFromJSON(json: any): QzResponseOfAddTeamResponseData {
    return QzResponseOfAddTeamResponseDataFromJSONTyped(json, false);
}

export function QzResponseOfAddTeamResponseDataFromJSONTyped(json: any, ignoreDiscriminator: boolean): QzResponseOfAddTeamResponseData {
    if (json == null) {
        return json;
    }
    return AddTeamResponseFromJSONTyped(json, true);
}

export function QzResponseOfAddTeamResponseDataToJSON(value?: QzResponseOfAddTeamResponseData | null): any {
    if (value == null) {
        return value;
    }

    if (instanceOfAddTeamResponse(value)) {
        return AddTeamResponseToJSON(value as AddTeamResponse);
    }

    return {};
}
