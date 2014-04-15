package com.mvukovic2.tryone;

import android.app.AlertDialog;
import android.content.Context;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.app.Activity;
import android.os.Bundle;

/**
 * Created by Matej on 13.04.14..
 * Kao što kaže, mozak za gps dio aplikacije.
 * Izvlači koordinate i šalje ih dalje
 * So let's make it rain..
 */
public class gpsBrain {
    Context mMontekst;
    double llong; //longitude
    double llat; //latitude
    String lok;

    public gpsBrain(Context mKontekst){
        this.mMontekst = mKontekst;

        LocationManager lm = (LocationManager)mKontekst.getSystemService(Context.LOCATION_SERVICE);
        LocationListener ll = new listenerLokacije();

        lm.requestLocationUpdates(LocationManager.GPS_PROVIDER, 0, 0, ll);

    }



        //Inner Class ...
        class listenerLokacije implements LocationListener {
            @Override
            public void onLocationChanged(Location location) {
                if(location != null)
                {
                    llong = location.getLongitude(); /*location.getLongitude();*/
                    llat = location.getLatitude();
                    lok = String.format("Lat: "+ llat + " Long: " + llong );
                }
            }

            @Override
            public void onStatusChanged(String s, int i, Bundle bundle) {

            }

            @Override
            public void onProviderEnabled(String s) {

            }

            @Override
            public void onProviderDisabled(String s) {

            }
        } // private Class

        public String postavi()
        {

            String lokacija = String.format("Lat: "+ llat + " Long: " + llong );
            return lok;
        }
    }



    



