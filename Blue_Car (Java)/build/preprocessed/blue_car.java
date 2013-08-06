import java.util.*;
import java.io.*;
import javax.microedition.io.*;
import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;
import javax.bluetooth.*;

public class blue_car extends MIDlet implements CommandListener{

	public Display display;
	public Form discoveryForm;
	public Form readyToConnectForm;
	public ImageItem mainImageItem;
	public Image mainImage;
	public Image bt_logo;
	public TextField addressTextField;
	public TextField subjectTextField;
	public TextField messageTextField;
	public Command selectCommand;
	public Command exitCommand;
	public Command connectCommand;
	public List devicesList;
	public Thread btUtility;
	public String btConnectionURL;
	public boolean sendData = false;
    public byte[] outSerial = {0};
    private KeyCodeCanvas canvas;
    public String serialView_out="0";
    public String buttonID="_";
    public String HDLED="Head Lights OFF";
    public String BRKLED="Brake Lights OFF";

//////////////////////////////////////////////////

	public blue_car() {
		display=Display.getDisplay(this);
		discoveryForm = new Form("Blue Car Remote");

		try{
			mainImage = Image.createImage("/btcar.png");
            bt_logo = Image.createImage("/btlogo.png");
		} catch (java.io.IOException e){
			e.printStackTrace();
		}
		mainImageItem = new ImageItem("R/C Car Remote over Bluetooth", mainImage, Item.LAYOUT_CENTER, "");
		discoveryForm.append(mainImageItem);

		btUtility = new BTUtility();

		/// discoveryForm commands initialization

		exitCommand = new Command("Exit", Command.EXIT, 1);
		discoveryForm.addCommand(exitCommand);
		discoveryForm.setCommandListener(this);

		/// devicesList initialization

        devicesList = new List("Select Bluetooth-enabled Car", Choice.IMPLICIT, new String[0], new Image[0]);
		selectCommand = new Command("Select", Command.ITEM, 1);
		devicesList.addCommand(selectCommand);
        devicesList.addCommand(exitCommand);
        devicesList.setCommandListener(this);
        devicesList.setSelectedFlags(new boolean[0]);

		/// readyToConnectForm initialization

		readyToConnectForm = new Form("Ready to Connect");
		readyToConnectForm.append("The selected Bluetooth device is ready to connect.");
		connectCommand = new Command("Connect", Command.ITEM, 1);
		readyToConnectForm.addCommand(connectCommand);
        readyToConnectForm.addCommand(exitCommand);
		readyToConnectForm.setCommandListener(this);

        /// Initailize Canvas
        canvas = new KeyCodeCanvas();
        canvas.addCommand(exitCommand);
        canvas.setCommandListener(this);

    	}


	public void commandAction(Command command, Displayable d) {
		if(command == selectCommand) {
			btUtility.start();
		}
		if(command == exitCommand ) {
			sendData = false;
			destroyApp(true);
		}
		if(command == connectCommand ) {
			Thread commReaderThread = new COMMReader();
			commReaderThread.start();
			display.setCurrent(canvas);
		}

	}


	public void startApp() {
		display.setCurrent(discoveryForm);
	}

	public void pauseApp() {

	}

	public void destroyApp(boolean b) {
		notifyDestroyed();
	}


////////////////

    /**
     * This is an inner class that is used for finding
     * Bluetooth devices in the vicinity
     *
     */
    class BTUtility extends Thread implements DiscoveryListener{

        Vector remoteDevices = new Vector();
        Vector deviceNames = new Vector();

        DiscoveryAgent discoveryAgent;

        public BTUtility() {

            try {
                LocalDevice localDevice = LocalDevice.getLocalDevice();
                discoveryAgent = localDevice.getDiscoveryAgent();
                discoveryForm.append("Searching for Bluetooth devices in the vicinity...");
                discoveryAgent.startInquiry(DiscoveryAgent.GIAC, this);
            } catch(BluetoothStateException e) {
                discoveryForm.append("Failed to iniate bluetooth module.");
                e.printStackTrace();
            }
        }

        public void deviceDiscovered(RemoteDevice remoteDevice, DeviceClass cod) {
            try{
 		   discoveryForm.append("\nfound: " + remoteDevice.getFriendlyName(true));
            } catch(Exception e){
                e.printStackTrace();
               discoveryForm.append("\nfound: " + remoteDevice.getBluetoothAddress());
            } finally{
		   remoteDevices.addElement(remoteDevice);
		}
        }



        public void inquiryCompleted(int discType) {

            if (remoteDevices.size() > 0) {

                // the discovery process was a success
                // so let's out them in a List and display it to the user
                for (int i=0; i<remoteDevices.size(); i++){
                    try{
                       devicesList.append(((RemoteDevice)remoteDevices.elementAt(i)).getFriendlyName(true), bt_logo);
                    } catch (Exception e){
                       devicesList.append(((RemoteDevice)remoteDevices.elementAt(i)).getBluetoothAddress(), bt_logo);
                    }
                }
                display.setCurrent(devicesList);
            } else {
			// no devices found in range
            discoveryForm.append("\nNo Devices Found.");
		}

        }

        
// program gets connection data here
        public void run(){
            try {
                // picks selected device
                RemoteDevice remoteDevice = (RemoteDevice)remoteDevices.elementAt(devicesList.getSelectedIndex());
                // gets Bluetooth address, and creates connection URL in format:
                // btspp://[Insert Bluetooth address here]:1;authenticate=false;encrypt=false;master=false
                btConnectionURL = "btspp://" + remoteDevice.getBluetoothAddress() + ":1;authenticate=false;encrypt=false;master=false";
                display.setCurrent(readyToConnectForm);
                readyToConnectForm.append("\n\nThe Bluetooth connection address is: " + remoteDevice.getBluetoothAddress());
            } catch(Exception e) {
                e.printStackTrace();
            }
        }

        public void servicesDiscovered(int transID, ServiceRecord[] servRecord){

        }

        public void serviceSearchCompleted(int transID, int respCode) {

        }

   }
////////////////


////////////////

    /**
     * This is an inner class that is used for sending
     * the serial stream of data to a RFCOMM device
     *
     */
    class COMMReader extends Thread {

	public COMMReader() {

	}

	public void run(){

		try{
			StreamConnection connection = (StreamConnection)Connector.open(btConnectionURL);
            OutputStream out = connection.openOutputStream();

            byte temp = 0;

            // sendData is set false by default and an Exit Command
			sendData = true;

            // everything RFCOM-wise happens in this while-loop
			while(sendData == true){

                // if new output data is available, send and write to form
                if (outSerial[0] != temp){
                    temp = outSerial[0];
                    out.write(outSerial[0]);
                    serialView_out = Integer.toBinaryString(outSerial[0]);
                }

                // refresh Canvas
                canvas.repaint();

			}

			connection.close();

		}catch(IOException ioe){
			ioe.printStackTrace();
		}


	}


    }

////////////////


////////////////

       /**
        * This is an inner class used for making a canvas to
        * display serial I/O and process keypad changes
        */

    class KeyCodeCanvas extends Canvas{

        byte star_stat = 0;
        byte zero_stat = 0;
        byte square_stat = 0;

        public KeyCodeCanvas(){
        }

        protected void paint(Graphics g) {

            // Clear the background (to white)
            g.setColor(255,255,255);
            g.fillRect(0, 0, getWidth(), getHeight());

            // draws data strings
            g.setColor(0,0,255);
            g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_PLAIN, Font.SIZE_LARGE));
            g.drawString(serialView_out, 165, 65, Graphics.RIGHT|Graphics.BASELINE);

            // Covers little error area from bytes over 7 bits. ;-)
            g.setColor(255,255,255);
            g.fillRect(0, 0, 85, getHeight());

            // write title and labels
            g.setColor(0,0,0);
            g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_LARGE));
            g.drawString("Serial I/O:", (getWidth()/2), 25, Graphics.HCENTER|Graphics.BASELINE);
            g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_UNDERLINED, Font.SIZE_LARGE));
            g.drawString("Output:", 15, 65, Graphics.LEFT|Graphics.BASELINE);

            // draws button status strings
            g.setColor(0,0,0);
            g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_PLAIN, Font.SIZE_MEDIUM));
            g.drawString(buttonID, (getWidth()/2), 105, Graphics.HCENTER|Graphics.BASELINE);
            g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_PLAIN, Font.SIZE_LARGE));
            g.drawString(HDLED, 20, 135, Graphics.LEFT|Graphics.BASELINE);
            g.drawString(BRKLED, 20, 155, Graphics.LEFT|Graphics.BASELINE);

        }

        protected void keyPressed(int keyCode){

            /* works from 0 to 0b1111111
            outSerial={127,63,31,15,7,3,1,0};*/

             switch (keyCode){
                 case KEY_NUM2: {
                     outSerial[0] = (byte) (outSerial[0] | 16);
                     buttonID = "UP";
                     break;
                 }
                 case KEY_NUM5: {
                     outSerial[0] = (byte) (outSerial[0] | 32);
                     buttonID = "DOWN";
                     break;
                 }
                 case KEY_NUM4: {
                     outSerial[0] = (byte) (outSerial[0] | 4);
                     buttonID = "LEFT";
                     break;
                 }
                 case KEY_NUM6: {
                     outSerial[0] = (byte) (outSerial[0] | 8);
                     buttonID = "RIGHT";
                     break;
                 }
                 case KEY_STAR: {
                     if (star_stat==0){
                        outSerial[0] = (byte) (outSerial[0] | 128);
                        star_stat = 1;
                        HDLED = "Head Lights ON";
                     }else{
                        outSerial[0] = (byte) (outSerial[0] & 124);
                        star_stat = 0;
                        HDLED = "Head Lights OFF";
                     }
                     buttonID = "STAR";
                     break;
                 }
                 case KEY_POUND: {
                     if (square_stat==0){
                        outSerial[0] = (byte) (outSerial[0] | 64);
                        square_stat = 1;
                        BRKLED = "Brake Lights ON";
                     }else{
                        outSerial[0] = (byte) (outSerial[0] & 188);
                        square_stat = 0;
                        BRKLED = "Brake Lights OFF";
                     }
                     buttonID = "SQUARE";
                     break;
                 }
                 default: buttonID = "Invalid"; break;
             }

             // display change in I/O
             canvas.repaint();
         }

         protected void keyReleased(int keyCode){

             switch (keyCode){
                 case KEY_NUM2: {
                     outSerial[0] = (byte) (outSerial[0] & 236);
                     buttonID = " ";
                     break;
                 }
                 case KEY_NUM5: {
                     outSerial[0] = (byte) (outSerial[0] & 220);
                     buttonID = " ";
                     break;
                 }
                 case KEY_NUM4: {
                     outSerial[0] = (byte) (outSerial[0] & 248);
                     buttonID = " ";
                     break;
                 }
                 case KEY_NUM6: {
                     outSerial[0] = (byte) (outSerial[0] & 244);
                     buttonID = " ";
                     break;
                 }
                 default:buttonID = " "; break;
             }

             // display change in I/O
             canvas.repaint();
         }

    }

}






