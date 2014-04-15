package com.mvukovic2.tryone;

import android.content.Context;
import android.os.AsyncTask;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TabHost;
import android.widget.TextView;

public class MainActivity extends ActionBarActivity {



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Context context;
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        TabHost tabHost = (TabHost) findViewById(R.id.tabHost);
        tabHost.setup();

        TabHost.TabSpec tabSpec = tabHost.newTabSpec("lokacija");
        tabSpec.setContent(R.id.Lokacija);
        tabSpec.setIndicator("Nova Ruta");
        tabHost.addTab(tabSpec);

        tabSpec = tabHost.newTabSpec("radniSati");
        tabSpec.setContent(R.id.RadniSati);
        tabSpec.setIndicator("Unos Radnih Sati");
        tabHost.addTab(tabSpec);

        final Button btnZapocni = (Button)findViewById(R.id.btnZapocni);
        final Button btnZavrsi = (Button) findViewById(R.id.btnZavrsi);
        final TextView texLokacija = (TextView)findViewById(R.id.texLokacija);

        final gpsBrain gps = new gpsBrain(this);

        //Kreni sa drugom dretvom
        /*new osvjezavanjeKoordinata(this).execute(this);*/


        final EditText editTexBrPutRadLista = (EditText) findViewById(R.id.editTexBrPutRadLista);

        editTexBrPutRadLista.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i2, int i3) {
                //Nope
            }
            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i2, int i3) {
                //Nope ponovo
            }
            @Override
            public void afterTextChanged(Editable editable) {
                if(editTexBrPutRadLista.getText().toString() != null)
                {
                    btnZapocni.setEnabled(true);
                    btnZavrsi.setEnabled(true);
                }
            }
        });

       btnZavrsi.setOnClickListener(new View.OnClickListener() {
           @Override
           public void onClick(View view) {
                texLokacija.setText(gps.postavi());
           }
       });
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

}
