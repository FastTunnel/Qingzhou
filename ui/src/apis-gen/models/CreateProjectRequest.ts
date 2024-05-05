/* tslint:disable */
/* eslint-disable */
/**
 * Qz.WebApi
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface CreateProjectRequest
 */
export interface CreateProjectRequest {
    /**
     * 
     * @type {string}
     * @memberof CreateProjectRequest
     */
    projectName?: string;
    /**
     * 
     * @type {string}
     * @memberof CreateProjectRequest
     */
    describe?: string;
}

/**
 * Check if a given object implements the CreateProjectRequest interface.
 */
export function instanceOfCreateProjectRequest(value: object): boolean {
    return true;
}

export function CreateProjectRequestFromJSON(json: any): CreateProjectRequest {
    return CreateProjectRequestFromJSONTyped(json, false);
}

export function CreateProjectRequestFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateProjectRequest {
    if (json == null) {
        return json;
    }
    return {
        
        'projectName': json['projectName'] == null ? undefined : json['projectName'],
        'describe': json['describe'] == null ? undefined : json['describe'],
    };
}

export function CreateProjectRequestToJSON(value?: CreateProjectRequest | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'projectName': value['projectName'],
        'describe': value['describe'],
    };
}
